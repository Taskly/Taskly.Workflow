namespace WorkflowService.Domain
{
    public class WorkItemStatus
    {
        public WorkItemStatus(string title)
        {
            Title = title;
        }

        public string Title { get; }
    }
}
