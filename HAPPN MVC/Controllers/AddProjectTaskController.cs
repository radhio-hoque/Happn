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
        private readonly HAPPANDBContext db;

        public AddProjectTaskController(HAPPANDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.db = hAPPAN_MVC_AuthDBContext;
        }

        // GET: AddProjectTask/Create
        public IActionResult Index(int id)
        {
            ViewBag.ProjectId = id;
            return View();
        }

        ////POST: AddProjectTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                ProjectTask projectTask = new ProjectTask
                {
                    TaskName = task.TaskName,
                    PercentageOfProject = task.PercentageOfProject,
                    ProjectId = task.ProjectId
                };
                db.Tasks.Add(projectTask);
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Info", "CurrentProject", new
            {
                projectId = task
                    .ProjectId
            });
        }

        public ActionResult Edit(int id)
        {
            var ProjectTask = db.Tasks.Find(id);
            return View(ProjectTask);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                var Task = db.Tasks.Find(task.TaskId);
                Task.TaskName = task.TaskName;
                Task.PercentageOfProject = task.PercentageOfProject;
                await db.SaveChangesAsync();
            }
            return RedirectToAction("Info", "CurrentProject", new
            {
                projectId = task
                    .ProjectId
            });
        }
    }
}
