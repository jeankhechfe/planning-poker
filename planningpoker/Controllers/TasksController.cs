using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Controllers.Exceptions;
using planningpoker.Models;
using planningpoker.Services;
using planningpoker.TOs;

namespace planningpoker.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TasksController : Controller
    {
        private readonly TaskService _taskService;

        public TasksController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet("{id}")] 
        public ActionResult<TaskTO> GetTask(string id) 
        {
            try
            {
                return _taskService.GetTask(id).toTO();
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("project/{projectId}")] 
        public ActionResult<List<TaskTO>> GetAllForProject(string projectId) 
        {
            try
            {
                return _taskService.GetTasksForProject(projectId).Select(t => t.toTO()).ToList();
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("user/{userId}")] 
        public ActionResult<List<TaskTO>> GetAllForUser(string userId) 
        {
            try
            {
                return _taskService.GetTasksForUser(userId).Select(t => t.toTO()).ToList();
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public ActionResult<TaskTO> CreateNewTask(TaskCreateTO taskCreateTo)
        {
            try
            {
                return _taskService.CreateTask(taskCreateTo).toTO();
            }            
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpPut("{taskId}")]
        public ActionResult<TaskTO> UpdateTask(string taskId, TaskCreateTO taskCreateTo)
        {
            try
            {
                return _taskService.UpdateTask(taskId, taskCreateTo).toTO();
            }            
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{taskId}")]
        public ActionResult DeleteTask(string taskId)
        {
            try
            {
                _taskService.DeleteTask(taskId);
                return Ok();
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }

        [HttpGet("{taskId}/comments")] 
        public ActionResult<List<CommentTO>> GetComments(string taskId) 
        {
            try
            {
                return _taskService.GetCommentsForTask(taskId).Select(c=>c.toTO()).ToList();
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpPost("{taskId}/comments")] 
        public ActionResult<CommentTO> AddComment(string taskId, CommentCreateTO commentCreateTo) 
        {
            try
            {
                if (!taskId.Equals(commentCreateTo.TaskId))
                    return Conflict();
                else
                {
                    if (commentCreateTo.TaskId == null)
                        commentCreateTo.TaskId = taskId;

                    return _taskService.AddComment(commentCreateTo).toTO();
                }
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{taskId}/comments/{commentId}")] 
        public ActionResult DeleteComment(string taskId, string commentId) 
        {
            try
            {
                _taskService.DeleteComment(commentId);
                return Ok();
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpGet("{taskId}/estimations")] 
        public ActionResult<List<UserTaskEstimationTO>> GetEstimations(string taskId) 
        {
            try
            {
                return _taskService.GetTaskEstimationsForTask(taskId)
                    .Select(c=>c.toTO())
                    .ToList();
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpPost("{taskId}/estimations")] 
        public ActionResult<UserTaskEstimationTO> AddComment(string taskId, UserTaskEstimationCreateTO to) 
        {
            try
            {
                if (!taskId.Equals(to.TaskId))
                    return Conflict();
                else
                {
                    if (to.TaskId == null)
                        to.TaskId = taskId;

                    return _taskService.SetEstimation(to).toTO();
                }
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
        
        [HttpDelete("{taskId}/estimations/{estimationId}")] 
        public ActionResult DeleteEstimation(string taskId, string estimationId) 
        {
            try
            {
                _taskService.DeleteEstimation(estimationId);
                return Ok();
            } 
            catch (NotFoundException)
            {
                return NotFound();
            }
            catch (IncompleteDataException)
            {
                return BadRequest();
            }
        }
    }
}