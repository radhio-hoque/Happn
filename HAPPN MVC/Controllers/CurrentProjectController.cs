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
    public class CurrentProjectController : Controller
    {
        private readonly HAPPANDBContext hAPPAN_MVC_AuthDBContext;
        public CurrentProjectController(HAPPANDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }
     

        public IActionResult Info(int projectId)
        {
            if(projectId == 0)
            {
                return Redirect("/");
            }
            IList<ProjectTask> projects = hAPPAN_MVC_AuthDBContext.Tasks.Where(c => c.ProjectId == projectId).ToList();
            return View(projects);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> DeleteTask(int? id)
        {
            var task = await hAPPAN_MVC_AuthDBContext.Tasks.FindAsync(id);
            hAPPAN_MVC_AuthDBContext.Tasks.Remove(task);
            await hAPPAN_MVC_AuthDBContext.SaveChangesAsync();
            return RedirectToAction("Info", "CurrentProject");
        }

    }

 
}
