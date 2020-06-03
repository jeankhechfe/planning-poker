using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Controllers.Exceptions;
using planningpoker.Models;
using planningpoker.TOs;

namespace planningpoker.Controllers
{
    [Route("api/projects")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet] 
        public ActionResult<List<ProjectTO>> GetAll([FromHeader] string authorization) 
        {     
            string userId = authorization.Replace("Bearer ", "");
            return _projectService.GetAllUserHasPermissionTo(userId)
                .Select(p => p.toTO())
                .ToList(); 
        }

        [HttpGet("{id}")] 
        public ActionResult<Project> GetById(string id) 
        {    
            var item = _projectService.Get(id);
            
            if (item == null)    
                return NotFound();     
            else
                return item;
        }
        
        [HttpPost] 
        public ActionResult<ProjectTO> Create(Project project, [FromHeader] string authorization)
        {
            string userId = authorization.Replace("Bearer ", "");
            
            _projectService.CreateProject(project, userId);
            return project.toTO();
        }
        
        [HttpPut("{id}")] 
        public ActionResult<Project> Update(string id, ProjectCreatingTO project, [FromHeader] string authorization) 
        {    
            var item = _projectService.Get(id);
            
            if (item == null)    
                return NotFound();
            else
            {
                string userId = authorization.Replace("Bearer ", "");
                return _projectService.Update(item, project, userId); 
            }
        }
        
        [HttpDelete("{id}")] 
        public ActionResult<Project> Delete(string id, [FromHeader] string authorization) 
        {    
            var item = _projectService.Get(id);
            
            if (item == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    string userId = authorization.Replace("Bearer ", "");
                    _projectService.Remove(id, userId);
                    return Ok();
                }
                catch (AccessForbiddenException)
                {
                    return BadRequest();
                }

            }
        }
    }
}