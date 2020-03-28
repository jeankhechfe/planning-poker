using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using planningpoker.Models;

namespace planningpoker.Controllers
{
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
 
        [HttpGet("{id}", Name = "GetProject")] 
        public ActionResult<Project> GetById(string id) 
        {    
            var item = _projectService.Get(id);
            
            if (item == null)    
                return NotFound();     
            else
                return item;
        }
    }
}