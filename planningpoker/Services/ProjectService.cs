using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using planningpoker.Controllers.Exceptions;
using planningpoker.Services;
using planningpoker.TOs;

namespace planningpoker.Models
{
    public class ProjectService
    {
        private readonly ProjectContext _projectContext;
        private readonly UserService _userService;

        public ProjectService(ProjectContext projectContext, UserService userService)
        {
            _projectContext = projectContext;
            _userService = userService;
        }

        public Project CreateProject(Project project, string userId)
        {
            project.Id = Guid.NewGuid().ToString();

            UserProjectPermission permission = new UserProjectPermission();
            permission.Id = Guid.NewGuid().ToString();
            permission.PermissionType = PermissionType.OWNER;
            permission.UserId = userId;
            permission.ProjectId = project.Id;

            _projectContext.Add(project);
            _projectContext.Add(permission);
            _projectContext.SaveChanges();
            return project;
        }

        List<Project> GetAll()
        {
            return new List<Project>(_projectContext.Projects);
        }
        
        public List<Project> GetAllUserHasPermissionTo(string userId)
        {
            var userProjectPermissions = _projectContext.ProjectPermissions
                .Where(pp => pp.UserId.Equals(userId));
            return _projectContext.Projects
                .Where(p => userProjectPermissions.First(upp => upp.ProjectId == p.Id) != null)
                .ToList();
        }
        
        public Project Get(string id)
        {
            var project = GetAll().Find(p => p.Id.Equals(id));
            if(project == null)
                throw new NotFoundException("No project found of id " + id);
            return project;
        }
        
        public Project Update(Project existing, ProjectCreatingTO update, string userId)
        {
            var projectsPermissionsForProject = GetProjectsPermissionsForProject(existing.Id);
            var userProjectPermissionTo = projectsPermissionsForProject.Find(upp => upp.UserId == userId);
            
            if(userProjectPermissionTo == null)
                throw new AccessForbiddenException();
            
            existing.Name = update.Name;
            existing.Description = update.Description;
            var entity = _projectContext.Update(existing).Entity;
            _projectContext.SaveChanges();
            return entity;
        }
        
        public void Remove(string id, string userId)
        {
            Project project = GetAll().Find(p => p.Id.Equals(id));
            if (project == null)
                throw new NotFoundException("No project found of id " + id);

            var projectsPermissionsForProject = GetProjectsPermissionsForProject(id);
            var userProjectPermissionTo = projectsPermissionsForProject.Find(upp => upp.UserId == userId);
            
            if(userProjectPermissionTo == null)
                throw new AccessForbiddenException();

            foreach (var projectPermissionTo in projectsPermissionsForProject)
            {
                RevokeAccessToProject(id, projectPermissionTo.UserId);
            }

            // _taskService.GetTasksForProject(project.Id)
                // .ForEach(t => _taskService.DeleteTask(t.Id));

            _projectContext.Tasks
                .Where(task => task.ProjectId == id)
                .ToList()
                .ForEach(t =>
                {
                    _projectContext.Comments
                        .Where(c => c.TaskId == t.Id)
                        .ToList()
                        .ForEach(c => _projectContext.Comments.Remove(c));

                    _projectContext.TaskEstimations
                        .Where(c => c.TaskId == t.Id)
                        .ToList()
                        .ForEach(c => _projectContext.TaskEstimations.Remove(c));
                });

            _projectContext.Projects.Remove(project);
            _projectContext.SaveChanges();
        }

        public List<UserProjectPermissionTO> GetProjectsPermissionsForUser(string userId)
        {
            var user = _userService.GetUser(userId);
            
            var projectsPermissionsForUser = _projectContext.ProjectPermissions
                .Where(upp => upp.UserId.Equals(userId))
                .Select(upp => upp.toTO())
                .ToList();
            return projectsPermissionsForUser;
        }
        
        public List<UserProjectPermissionTO> GetProjectsPermissionsForProject(string projectId)
        {
            var project = Get(projectId);
            var projectsPermissionsForProject = _projectContext.ProjectPermissions
                .Where(upp => upp.ProjectId.Equals(projectId))
                .Select(upp => upp.toTO())
                .ToList();
            return projectsPermissionsForProject;
        }

        public UserProjectPermissionTO SetProjectPermission(UserProjectPermissionTO userProjectPermission)
        {
            if (userProjectPermission.PermissionType == null)
            {
                throw new IncompleteDataException("Permission Type cannot be nulled");
            }
            else if (userProjectPermission.ProjectId == null || userProjectPermission.ProjectId.Equals(""))
            {
                throw new IncompleteDataException("ProjectId cannot be nulled");
            }
            else if (userProjectPermission.UserId == null || userProjectPermission.UserId.Equals(""))
            {
                throw new IncompleteDataException("UserId cannot be nulled");
            }
            else
            {
                var permissions = _projectContext.ProjectPermissions.Where(upp =>
                    upp.UserId.Equals(userProjectPermission.UserId)
                        && upp.ProjectId.Equals(userProjectPermission.ProjectId)
                ).ToList();

                if (permissions.Count > 0)
                {
                    //TODO truncate to have just one permission entity
                    
                    return permissions[0].toTO();
                }
                else
                {
                    Project project = Get(userProjectPermission.ProjectId);
                    User user = _userService.GetUser(userProjectPermission.UserId);
                
                    UserProjectPermission projectPermission = new UserProjectPermission()
                    {

                        Id = Guid.NewGuid().ToString(),
                        PermissionType = userProjectPermission.PermissionType,
                        ProjectId = userProjectPermission.ProjectId,
                        Project = project,
                        User = user,
                        UserId = userProjectPermission.UserId
                    };
                
                    _projectContext.ProjectPermissions.Add(projectPermission);
                    _projectContext.SaveChanges();

                    return projectPermission.toTO();
                }
            }
        }

        public void RevokeAccessToProject(string projectId, string userId)
        {
            if (projectId == null || projectId.Equals(""))
            {
                throw new IncompleteDataException("ProjectId cannot be nulled");
            }
            else if (userId == null || userId.Equals(""))
            {
                throw new IncompleteDataException("UserId cannot be nulled");
            }
            else
            {
                _projectContext.ProjectPermissions
                    .Where(upp => upp.UserId.Equals(userId) && upp.ProjectId.Equals(projectId))
                    .ForEachAsync(upp => _projectContext.ProjectPermissions.Remove(upp))
                    .GetAwaiter()
                    .GetResult();
            }

        } 

    }
}