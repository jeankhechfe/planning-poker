using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
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
        public ActionResult<Project> Update(string id, ProjectCreatingTO project) 
        {    
            var item = _projectService.Get(id);
            
            if (item == null)    
                return NotFound();
            else
            {
                return _projectService.Update(item, project); 
            }
        }
        
        [HttpDelete("{id}")] 
        public ActionResult<Project> Delete(string id) 
        {    
            var item = _projectService.Get(id);
            
            if (item == null)    
                return NotFound();
            else
            {
                _projectService.Remove(id);
                return Ok();
            }
        }
    }
}