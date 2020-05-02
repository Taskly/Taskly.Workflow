namespace WorkflowService.WebApi.Dto.WorkItems
{
    public class WorkItemStatusDto
    {
        public WorkItemStatusDto(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
