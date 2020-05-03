using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Dto.WorkItems;

namespace Taskly.Workflow.WebApi.Controllers
{
    [Route("api/work-items")]
    public class WorkItemsController : ControllerBase
    {
        public WorkItemsController(IWorkItemsRepository workItemsRepository)
        {
            _workItemsRepository = workItemsRepository;
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkItemDto>> GetWorkItems(string id)
        {
            WorkItem workItem = await _workItemsRepository.GetWorkItem(id);
            var dto = new WorkItemDto(workItem);
            return Ok(dto);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<WorkItemDto>> CreateWorkItem([FromBody] WorkItemCreateDto dto)
        {
            var workItemStatus = new WorkItemStatus(dto.Status.Title);
            var workItem = new WorkItem(dto.ProjectId, dto.Title, dto.Description, workItemStatus);
            workItem = await _workItemsRepository.SaveWorkItem(workItem);
            return CreatedAtAction(nameof(GetWorkItems), new { id = workItem.Id }, workItem);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteWorkItem(string id)
        {
            await _workItemsRepository.DeleteWorkItem(id);
            return Ok();
        }

        private readonly IWorkItemsRepository _workItemsRepository;
    }
}
