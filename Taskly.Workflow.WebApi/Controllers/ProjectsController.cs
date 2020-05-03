using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Dto.Projects;
using Taskly.Workflow.WebApi.Dto.WorkItems;

namespace Taskly.Workflow.WebApi.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(IProjectsRepository projectsRepository, IWorkItemsRepository workItemsRepository)
        {
            _projectsRepository = projectsRepository;
            _workItemsRepository = workItemsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ProjectsListDto>> GetProjectsList()
        {
            List<Project> projects = await _projectsRepository.GetProjects();
            List<ProjectDto> dtoItems = projects.Select(x => new ProjectDto(x)).ToList();
            var dto = new ProjectsListDto(dtoItems);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjectWorkItemsDto>> GetProject(string id)
        {
            Project project = await _projectsRepository.GetProject(id);
            List<WorkItem> workItems = await _workItemsRepository.GetWorkItemsByProject(project.Id);
            var dto = new ProjectWorkItemsDto(project, workItems);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WorkItemDto>> CreateProject([FromBody] ProjectCreateDto dto)
        {
            List<WorkItemStatus> availableStatues =
                dto.AvailableStatuses.Select(x => new WorkItemStatus(x.Title)).ToList();

            var project = new Project(dto.Title, dto.Description, availableStatues);
            project = await _projectsRepository.SaveProject(project);
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, project);
        }

        private readonly IProjectsRepository _projectsRepository;
        private readonly IWorkItemsRepository _workItemsRepository;
    }
}
