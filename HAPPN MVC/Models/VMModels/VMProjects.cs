using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HAPPAN_MVC.Models.VMModels
{
    public class VMProjects
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public string Tname { get; set; }
        public int ProjectProgress { get; set; }
        [EnumDataType(typeof(Status))]
        public Status Status { get; set; }
        public List<VMTask> Task { get; set; }
    }
    public class VMTask
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public float Progress { get; set; }

    }
}
