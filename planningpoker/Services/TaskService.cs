using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using planningpoker.Controllers.Exceptions;
using planningpoker.Models;
using planningpoker.TOs;
using planningpoker.Utils;

namespace planningpoker.Services
{
    public class TaskService
    {
        private readonly ProjectContext _projectContext;
        private readonly ProjectService _projectService;
        private readonly UserService _userService;

        public TaskService(ProjectContext projectContext, ProjectService projectService, UserService userService)
        {
            _projectContext = projectContext;
            _projectService = projectService;
            _userService = userService;
        }

        public Task CreateTask(TaskCreateTO taskCreateTo)
        {
            var task = new Task
            {
                Id = Guid.NewGuid().ToString(),
                
                Description = taskCreateTo.Description,
                Name = taskCreateTo.Name,
                Estimation = taskCreateTo.Estimation,
                ProjectId = taskCreateTo.ProjectID,
                Project = _projectService.Get(taskCreateTo.ProjectID),
                
                //optional fields
                AssigneeId = taskCreateTo.AssignedUserId,
                Assignee = taskCreateTo.AssignedUserId != null ? _userService.GetUser(taskCreateTo.AssignedUserId) : null
            };
            
            _projectContext.Tasks.Add(task);
            _projectContext.SaveChanges();

            return task;
        }

        public List<Task> GetTasksForProject(string projectId)
        {
            _projectService.Get(projectId);
            
            return _projectContext.Tasks
                .Include(t => t.Project)
                .Include(t => t.Assignee)
                .Where(t => t.ProjectId.Equals(projectId)).ToList();
        }
        
        public List<Task> GetTasksForUser(string userId)
        {
            _userService.GetUser(userId);
            
            return _projectContext.Tasks
                .Include(t => t.Project)
                .Include(t => t.Assignee)
                .Where(t => t.AssigneeId.Equals(userId)).ToList();
        }

        public Task UpdateTask(string taskId, TaskCreateTO taskCreateTo)
        {
            var task = GetTask(taskId);

            if(StringUtils.isStringNotEmpty(taskCreateTo.Name))
                task.Name = taskCreateTo.Name;
            if(StringUtils.isStringNotEmpty(taskCreateTo.Description))
                task.Description = taskCreateTo.Description;
            if(taskCreateTo.Estimation != 0)
                task.Estimation = taskCreateTo.Estimation;

            if (taskCreateTo.AssignedUserId != null && !task.AssigneeId.Equals(taskCreateTo.AssignedUserId))
            {
                task.Assignee = _userService.GetUser(taskCreateTo.AssignedUserId);
                task.AssigneeId = taskCreateTo.AssignedUserId;
            }
            
            if (taskCreateTo.AssignedUserId != null && !task.ProjectId.Equals(taskCreateTo.ProjectID))
            {
                task.Project = _projectService.Get(taskCreateTo.ProjectID);
                task.ProjectId = taskCreateTo.ProjectID;
            }

            _projectContext.Update(task);
            _projectContext.SaveChanges();

            return task;
        }

        public Task GetTask(string taskId)
        {
            var task = _projectContext.Tasks
                .Include(t => t.Project)
                .Include(t => t.Assignee)
                .Where(t => t.Id.Equals(taskId))
                .FirstOr(alternate: null);
            
            if (task == null)
                throw new NotFoundException("Task not found with id " + taskId);
            return task;
        }

        public void DeleteTask(string taskId)
        {
            GetCommentsForTask(taskId).ForEach(c=>_projectContext.Comments.Remove(c));
            GetTaskEstimationsForTask(taskId).ForEach(c=>_projectContext.TaskEstimations.Remove(c));
            _projectContext.Tasks.Remove(GetTask(taskId));
            _projectContext.SaveChanges();
        }

        public Comment AddComment(CommentCreateTO commentTo)
        {
            Comment comment = new Comment()
            {
                Created = DateTime.Now,
                Id = Guid.NewGuid().ToString(),
                Text = commentTo.Text,
                User = _userService.GetUser(commentTo.UserId),
                UserId = commentTo.UserId,
                Task = GetTask(commentTo.TaskId),
                TaskId = commentTo.TaskId
            };

            _projectContext.Comments.Add(comment);
            _projectContext.SaveChanges();

            return comment;
        }

        public List<Comment> GetCommentsForTask(string taskId)
        {
            return _projectContext.Comments
                .Include(c => c.Task)
                .Include(c => c.User)
                .Where(c => c.TaskId.Equals(taskId)).ToList();
        }
        
        public void DeleteComment(string commentId)
        {
            var comment = _projectContext.Comments.Find(commentId);
            if(comment == null)
                throw new NotFoundException("Comment not found of id " + commentId);

            _projectContext.Comments.Remove(comment);
            _projectContext.SaveChanges();
        }
        
        public UserTaskEstimation SetEstimation(UserTaskEstimationCreateTO commentTo)
        {

            UserTaskEstimation estimation = _projectContext.TaskEstimations
                    .Include(c => c.Task)
                    .Include(c => c.User)
                    .Where(e => e.TaskId.Equals(commentTo.TaskId) && e.UserId.Equals(commentTo.UserId))
                    .FirstOr(null)
                ;
            
            if(estimation == null)
            {
                estimation = new UserTaskEstimation()
                {
                    Updated = DateTimeOffset.Now,
                    Id = Guid.NewGuid().ToString(),
                    Estimation = commentTo.Estimation,
                    User = _userService.GetUser(commentTo.UserId),
                    UserId = commentTo.UserId,
                    Task = GetTask(commentTo.TaskId),
                    TaskId = commentTo.TaskId
                };
                
                _projectContext.TaskEstimations.Add(estimation);
                _projectContext.SaveChanges();
            }
            else
            {
                estimation.Estimation = commentTo.Estimation;
                estimation.Updated = DateTimeOffset.Now;
                _projectContext.TaskEstimations.Update(estimation);
                _projectContext.SaveChanges();
            }

            return estimation;
        }

        public List<UserTaskEstimation> GetTaskEstimationsForTask(string taskId)
        {
            return _projectContext.TaskEstimations
                .Include(c => c.Task)
                .Include(c => c.User)
                .Where(c => c.TaskId.Equals(taskId))
                .ToList();
        }
        
        public void DeleteEstimation(string estimationId)
        {
            var comment = _projectContext.TaskEstimations.Find(estimationId);
            
            if(comment == null)
                throw new NotFoundException("Comment not found of id " + estimationId);

            _projectContext.TaskEstimations.Remove(comment);
            _projectContext.SaveChanges();
        }
    }
}