using WorkflowService.Domain;

namespace WorkflowService.WebApi.Dto
{
    public class WorkItemStatusDto
    {
        public WorkItemStatusDto(WorkItemStatus model)
        {
            Title = model.Title;
        }

        public string Title { get; set; }
    }
}
