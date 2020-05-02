using System.Collections.Generic;

namespace WorkflowService.WebApi.Dto.Projects
{
    public class ProjectsList : ListBase<ProjectDto>
    {
        public ProjectsList(List<ProjectDto> items)
            : base(items)
        {
        }
    }
}
