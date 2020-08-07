using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HAPPAN_MVC.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }
        [Required]
        public string ProjectName { get; set; }
        [Required]
        public string ProjectProgress { get; set; }
        [Required]
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        public ICollection<ProjectTask> Tasks { get; set; }
    }

    public enum Status
    {
        Pending = 0,
        Canceled = 1,
        Success = 2
    }
}
