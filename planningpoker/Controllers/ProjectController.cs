using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Models;

namespace planningpoker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : Controller
    {
        private readonly ProjectService _projectService;

        public ProjectController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet] 
        public ActionResult<List<Project>> GetAll() 
        {     
            return _projectService.GetAll(); 
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
        public ActionResult<Project> Create(Project project) 
        {    
            _projectService.CreateProject(project);
            return project;
        }
        
        [HttpPut("{id}")] 
        public ActionResult<Project> Update(string id, Project project) 
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