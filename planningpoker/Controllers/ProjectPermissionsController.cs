using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Controllers.Exceptions;
using planningpoker.Models;
using planningpoker.TOs;

namespace planningpoker.Controllers
{
    [Route("api/permissions")]
    [ApiController]
    public class ProjectPermissionsController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectPermissionsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("user/{id}")] 
        public ActionResult<List<UserProjectPermissionTO>> GetAllForUser(string id)
        {
            try
            {
                return _projectService.GetProjectsPermissionsForUser(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("project/{id}")] 
        public ActionResult<List<UserProjectPermissionTO>> GetAllForProject(string id)
        {
            try
            {
                return _projectService.GetProjectsPermissionsForProject(id);
            }
            catch (NotFoundException)
            {
                return NotFound();
            }
        }
        
        [HttpPost] 
        public ActionResult<UserProjectPermissionTO> Update( UserProjectPermissionTO permission) 
        {
            try
            {
                return _projectService.SetProjectPermission(permission);
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
        
        [HttpDelete] 
        public ActionResult Delete(string projectId, string userId) 
        {
            try
            {
                _projectService.RevokeAccessToProject(projectId, userId);
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