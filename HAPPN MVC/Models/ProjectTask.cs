using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HAPPAN_MVC.Models
{
    public class ProjectTask
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string TaskName { get; set; }
        [Required]
        public int PercentageOfProject { get; set; }
        public int TaskProgress { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}
