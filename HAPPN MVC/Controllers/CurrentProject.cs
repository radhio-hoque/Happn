using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAPPAN_MVC.Data;
using HAPPAN_MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HAPPAN.Controllers
{
    public class CurrentProject : Controller
    {
        private readonly HAPPANDBContext hAPPAN_MVC_AuthDBContext;
        public CurrentProject(HAPPANDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }
     

        public IActionResult Info(int projectId)
        {
            if(projectId == 0)
            {
                return Redirect("/");
            }
            IList<ProjectTask> projects = hAPPAN_MVC_AuthDBContext.Tasks.Where(c => c.ProjectID == projectId).ToList();
            //var result = hAPPAN_MVC_AuthDBContext.Projects.ToList();
            return View(projects);
        }

    }
}
