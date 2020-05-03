using System.Collections.Generic;

namespace Taskly.Workflow.WebApi.Dto.Projects
{
    public class ProjectsListDto : ListBase<ProjectDto>
    {
        public ProjectsListDto(List<ProjectDto> items)
            : base(items)
        {
        }
    }
}
