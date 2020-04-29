namespace WorkflowService.WebApi.Dto
{
    public class ProjectInfoDto
    {
        public ProjectInfoDto(string title)
        {
            Title = title;
        }

        public string Title { get; set; }
    }
}
