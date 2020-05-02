using System.Collections.Generic;

namespace Taskly.Workflow.WebApi.Dto.Projects
{
    public class ProjectsList : ListBase<ProjectDto>
    {
        public ProjectsList(List<ProjectDto> items)
            : base(items)
        {
        }
    }
}
