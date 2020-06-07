using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Dto.Projects;

namespace Taskly.Workflow.WebApi.Controllers
{
    [Route("api/projects")]
    public class ProjectsController : ControllerBase
    {
        public ProjectsController(IMapper mapper, IProjectsRepository projectsRepository)
        {
            _mapper = mapper;
            _projectsRepository = projectsRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<ProjectDto>>> GetProjects()
        {
            List<Project> projects = await _projectsRepository.GetProjects();
            List<ProjectDto> dto = _mapper.Map<List<ProjectDto>>(projects);
            return Ok(dto);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProjectDto>> GetProject(string id)
        {
            Project project = await _projectsRepository.GetProject(id);
            ProjectDto dto = _mapper.Map<ProjectDto>(project);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ProjectDto>> CreateProject([FromBody] ProjectCreateDto dto)
        {
            List<WorkItemStatus> availableStatues =
                dto.AvailableStatuses.Select(x => new WorkItemStatus(x)).ToList();
            var project = new Project(dto.Title, dto.Description, availableStatues);
            project = await _projectsRepository.SaveProject(project);

            ProjectDto createdDto = _mapper.Map<ProjectDto>(project);
            return CreatedAtAction(nameof(GetProject), new { id = project.Id }, createdDto);
        }

        /*[HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateProject(string id, [FromBody] ProjectUpdateDto dto)
        {
            Project project = await _projectsRepository.GetProject(id);

            if (!string.IsNullOrEmpty(dto.Title))
            {
                project.Title = dto.Title;
            }

            if (!string.IsNullOrEmpty(dto.Description))
            {
                project.Description = dto.Description;
            }

            if (dto.AvailableStatuses != null)
            {
                // TODO: Validate AvailableStatuses
                project.AvailableStatuses = dto.AvailableStatuses.Select(x => x.ToModel()).ToList();
            }

            await _projectsRepository.SaveProject(project);
            return Ok();
        }*/

        private readonly IMapper _mapper;
        private readonly IProjectsRepository _projectsRepository;
    }
}
