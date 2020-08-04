using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAPPAN_MVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace HAPPAN.Controllers
{
    public class CurrentProject : Controller
    {
        private readonly HAPPAN_MVC_AuthDBContext hAPPAN_MVC_AuthDBContext;
        public CurrentProject(HAPPAN_MVC_AuthDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }
        public IActionResult Index()
        {
            var result = hAPPAN_MVC_AuthDBContext.Projects.ToList();
            return View();
        }

        public IActionResult Info(int projectId)
        {
           var myProject = hAPPAN_MVC_AuthDBContext.Projects.Find(projectId);
            ViewBag.ABc = myProject;
            return View(myProject);
        }

    }
}
