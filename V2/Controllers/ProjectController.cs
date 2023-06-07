using ApiVersioningTests.Data;
using ApiVersioningTests.V2.Models;
using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace ApiVersioningTests.V2.Controllers
{
    [Route("api/[controller]")]
	[Route("api/v{version:apiVersion}/[controller]")]
	[ApiVersion(2.0)]
    public class ProjectController : ControllerBase
    {
        private List<Project> _projects;

        public ProjectController()
        {
            _projects = Project.Projects;
        }

        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Project>), 200)]
        public IActionResult Get()
        {
            return Ok(_projects);
        }

        [HttpPost]
        [Consumes("application/json")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Project), 201)]
        [ProducesResponseType(400)]
        public IActionResult Post(CreateProjectRequest request)
        {
            var project = new Project(request.Name);

            _projects.Add(project);

            return CreatedAtAction(nameof(Get), new { Id = project.Id }, project);
        }

        [HttpGet("{id:int:min(1):required}")]
        [Produces("application/json")]
        [ProducesResponseType(typeof(Project), 200)]
        [ProducesResponseType(404)]
        public IActionResult Get(int id)
        {
            var project = _projects.SingleOrDefault(p => p.Id == id);

            if (project == null) return NotFound();
            return Ok(project);
        }

        [HttpPatch("{id:int:min(1):required}")]
        [Consumes("application/json")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult Patch([FromRoute] int id, UpdateProjectRequest request)
        {
            var project = _projects.SingleOrDefault(p => p.Id == id);

            if (project == null) return NotFound();

            project.Name = request.Name;

            return NoContent();
        }

        [HttpDelete("{id:int:min(1):required}")]
        [ProducesResponseType(204)]
        public IActionResult Delete([FromRoute] int id)
        {
            var project = _projects.SingleOrDefault(p => p.Id == id);
            _projects.Remove(project);

            return NoContent();
        }
    }
}