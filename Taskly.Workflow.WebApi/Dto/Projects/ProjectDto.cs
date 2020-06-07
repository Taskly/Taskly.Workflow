using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Taskly.Workflow.WebApi.Dto.Projects
{
    public class ProjectDto
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public DateTime Created { get; set; }

        [Required]
        public List<string> AvailableStatuses { get; set; }
    }
}
