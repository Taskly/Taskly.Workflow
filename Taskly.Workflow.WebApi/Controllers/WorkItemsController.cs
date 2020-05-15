﻿using System;
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
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<WorkItemDto>> GetWorkItem([FromRoute] Guid id)
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
            // TODO: Validate dto.ProjectId (project exists)
            var workItemStatus = new WorkItemStatus(dto.Status.Title);
            var workItem = new WorkItem(dto.ProjectId, dto.Title, dto.Description, workItemStatus);
            workItem = await _workItemsRepository.SaveWorkItem(workItem);
            return CreatedAtAction(nameof(GetWorkItem), new { id = workItem.Id }, workItem);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult> UpdateWorkItem([FromRoute] Guid id, [FromBody] WorkItemUpdateDto dto)
        {
            WorkItem workItem = await _workItemsRepository.GetWorkItem(id);

            if (!string.IsNullOrEmpty(dto.Title))
            {
                workItem.Title = dto.Title;
            }

            if (!string.IsNullOrEmpty(dto.Description))
            {
                workItem.Description = dto.Description;
            }

            if (dto.Status != null)
            {
                // TODO: Validate WorkItem Status (available in project)
                workItem.Status = dto.Status.ToModel();
            }

            await _workItemsRepository.SaveWorkItem(workItem);
            return Ok();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> DeleteWorkItem(Guid id)
        {
            await _workItemsRepository.DeleteWorkItem(id);
            return NoContent();
        }

        private readonly IWorkItemsRepository _workItemsRepository;
    }
}
