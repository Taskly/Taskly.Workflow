using System.Collections.Generic;
using Taskly.Workflow.Domain;

namespace Taskly.Workflow.WebApi.Dto.Projects
{
    public class ProjectsListDto : ListBase<ProjectDto>
    {
        public ProjectsListDto()
            : base(new List<ProjectDto>())
        {
        }

        public ProjectsListDto(List<ProjectDto> items)
            : base(items)
        {
        }
    }
}
