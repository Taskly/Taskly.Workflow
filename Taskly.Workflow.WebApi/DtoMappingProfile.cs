using System.Linq;
using AutoMapper;
using Taskly.Workflow.Domain;
using Taskly.Workflow.WebApi.Dto.Projects;
using Taskly.Workflow.WebApi.Dto.WorkItems;

namespace Taskly.Workflow.WebApi
{
    public class DtoMappingProfile : Profile
    {
        public DtoMappingProfile()
        {
            CreateMap<Project, ProjectDto>()
                .ForMember(x => x.AvailableStatuses, op => op.MapFrom(x => x.AvailableStatuses.Select(m => m.Title)));

            CreateMap<WorkItem, WorkItemDto>()
                .ForMember(x => x.Status, op => op.MapFrom(x => x.Status.Title));
        }
    }
}
