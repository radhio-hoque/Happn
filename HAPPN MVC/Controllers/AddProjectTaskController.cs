using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAPPAN_MVC.Data;
using HAPPAN_MVC.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HAPPAN_MVC.Controllers
{
    public class AddProjectTaskController : Controller
    {
        private readonly HAPPANDBContext hAPPAN_MVC_AuthDBContext;

        public AddProjectTaskController(HAPPANDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }

        // GET: AddProjectTask/Create
        public IActionResult Index(int id = 0)
        {
            if (id == 0)
                return View(new ProjectTask());
            else
                return View(hAPPAN_MVC_AuthDBContext.Tasks.Find(id));
        }

        // POST: AddProjectTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("TaskId,TaskName,PercentageOfProject,ProjectId")] ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0)
                    hAPPAN_MVC_AuthDBContext.Add(task);
                else
                    hAPPAN_MVC_AuthDBContext.Update(task);
                await hAPPAN_MVC_AuthDBContext.SaveChangesAsync();
                return RedirectToAction("Info", "CurrentProject");
            }
            return View(task);
        }
    }
}
