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

        //// GET: AddProjectTask
        //public ActionResult Index()
        //{
        //    return View();
        //}

        //// GET: AddProjectTask/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: AddProjectTask/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // GET: AddProjectTask/Create
        public IActionResult Create(int id = 0)
        {
            if (id == 0)
                return View(new ProjectTask());
            else
                return View(hAPPAN_MVC_AuthDBContext.Tasks.Find(id));
        }

        // POST: AddProjectTask/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskId,TaskName,PercentageOfProject,ProjectId")] ProjectTask task)
        {
            if (ModelState.IsValid)
            {
                if (task.TaskId == 0)
                    hAPPAN_MVC_AuthDBContext.Add(task);
                else
                    hAPPAN_MVC_AuthDBContext.Update(task);
                await hAPPAN_MVC_AuthDBContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");

            }
            return View(task);
        }

        //// GET: AddProjectTask/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: AddProjectTask/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: AddProjectTask/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: AddProjectTask/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
