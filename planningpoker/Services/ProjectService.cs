using System;
using System.Collections.Generic;

namespace planningpoker.Models
{
    public class ProjectService
    {
        private readonly ProjectContext _projectContext;

        public ProjectService(ProjectContext projectContext)
        {
            _projectContext = projectContext;
        }

        public Project CreateProject(Project project)
        {
            project.Id = Guid.NewGuid().ToString();

            ProjectPermission permission = new ProjectPermission();
            permission.Id = Guid.NewGuid().ToString();
            permission.PermissionType = PermissionType.OWNER;
            permission.HolderId = "user";//TODO 

            _projectContext.Add(project);
            _projectContext.Add(permission);
            _projectContext.SaveChanges();
            return project;
        }

        public List<Project> GetAll()
        {
            return new List<Project>(_projectContext.Projects);
        }
        
        public Project Get(string id)
        {
            return GetAll().Find(p => p.Id.Equals(id));
        }
        
        public Project Update(Project existing, Project update)
        {
            existing.Name = update.Name;
            var entity = _projectContext.Update(existing).Entity;
            _projectContext.SaveChanges();
            return entity;
        }
        
        public Project Remove(string id)
        {
            return GetAll().Find(p => p.Id.Equals(id));
        }
        
        //TODO
        private void SetWriteAccessForUserToProject(string projectId, string user)
        {
            
        }
        
        private void SetReadAccessForUserToProject(string projectId, string user)
        {
            
        }
        
        private void RevokeAccessToProject(string projectId, string user)
        {
            
        } 

    }
}