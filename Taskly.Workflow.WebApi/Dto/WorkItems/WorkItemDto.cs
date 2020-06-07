using System.ComponentModel.DataAnnotations;

namespace Taskly.Workflow.WebApi.Dto.WorkItems
{
    public class WorkItemDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string ProjectId { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public string Status { get; set; }
    }
}
