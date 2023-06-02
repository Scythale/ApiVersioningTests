using ApiVersioningTests.Data;
using ApiVersioningTests.V2.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningTests.V2.Controllers
{
    [Route("api/[controller]")]
    [ApiVersion(2.0)]
    public class ProjectController : ControllerBase
    {
        private List<Project> _projects;

        public ProjectController()
        {
            _projects = Project.Projects;
        }

        [HttpGet()]
        public IActionResult GetAll()
        {
            return Ok(_projects);
        }

        [HttpPost]
        public IActionResult Post(CreateProjectRequest request)
        {
            var project = new Project(request.Name);

            _projects.Add(project);

            return Ok(project.Id);
        }

        [HttpGet("{id:int:min(1):required}")]
        public IActionResult Get(int id)
        {
            var project = _projects.SingleOrDefault(p => p.Id == id);

            if (project == null) return NotFound();
            return Ok(project);
        }
    }
}