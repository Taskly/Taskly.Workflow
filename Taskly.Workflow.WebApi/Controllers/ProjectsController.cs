using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Dto.Projects;

namespace Taskly.Workflow.WebApi.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        /*[HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectsList>> GetProjectsList()
        {
            List<Project> projects = await _projectsRepository.GetProjectsInfo();
            List<ProjectInfoDto> dtoItems = projects.Select(x => new ProjectInfoDto(x.Title)).ToList();
            var dto = new ProjectsList(dtoItems);
            return Ok(dto);
        }*/

        /*[HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjectDto>> GetProject(string id)
        {
            Project project = await _projectsRepository.GetProject(id);
            var dto = new ProjectDto(project);
            return Ok(dto);
        }*/

        private readonly IProjectsRepository _projectsRepository;
    }
}
