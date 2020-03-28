using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

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
            _projectContext.Add(project);
            return project;
        }

        public List<Project> GetAll()
        {
            return new List<Project>(_projectContext.ProjectItems);
        }
        
        public Project Get(string id)
        {
            return GetAll().Find(p => p.Id.Equals(id));
        }
        
        public Project Update(Project project)
        {
            _projectContext.Update(project);
            return project;
        }
        
        public Project Remove(string id)
        {
            return GetAll().Find(p => p.Id.Equals(id));
        }
    }
}