using System.Collections.Generic;

namespace WorkflowService.WebApi.Dto
{
    public class ProjectsInfoList : ListBase<ProjectInfoDto>
    {
        public ProjectsInfoList(List<ProjectInfoDto> items)
            : base(items)
        {
        }
    }
}
