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
        public IActionResult Index(int id = 0)
        {
            if (id == 0)
                return View(new ProjectTask());
            else
                return View(db.Tasks.Find(id));
        }

        //POST: AddProjectTask/Create
       [HttpPost]
       [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("TaskId,TaskName,PercentageOfProject,ProjectId")] ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0)
                    db.Add(task);
                else
                    db.Update(task);
                await db.SaveChangesAsync();
                return RedirectToAction("Info", "CurrentProject");
            }
            return View(task);
        }

        //public IActionResult Index(ProjectTask task)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var projectid = db.Projects.Where(b => b.ProjectId == task.ProjectId);

        //        // no blog with this title yet, create a new one

        //        ProjectTask projectTask = new ProjectTask
        //        {
        //            TaskName = task.TaskName,
        //            PercentageOfProject = task.PercentageOfProject,
        //            Project = project
        //        };
        //        db.Tasks.Add(projectTask);
        //        db.SaveChanges();
        //        return RedirectToAction("Info", "CurrentProject");
        //    }
        //    return View(task);
        //}
    }
}
