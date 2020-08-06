using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HAPPAN_MVC.Data;
using HAPPAN_MVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace HAPPAN.Controllers
{
    public class AddProjectController : Controller
    {

        private readonly HAPPANDBContext hAPPAN_MVC_AuthDBContext;

        public AddProjectController(HAPPANDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }

        // GET: Employee/Create
        public IActionResult Index(int id = 0)
        {
            if (id == 0)
                return View(new Project());
            else
            
                return View(hAPPAN_MVC_AuthDBContext.Projects.Find(id));
        }

        // POST: Project/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index([Bind("ProjectId,ProjectName,ProjectProgress,Status")] Project Projects)
        {
            if (ModelState.IsValid)
            {
                if (Projects.ProjectId == 0)
                    hAPPAN_MVC_AuthDBContext.Add(Projects);
                else
                    hAPPAN_MVC_AuthDBContext.Update(Projects);
                await hAPPAN_MVC_AuthDBContext.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(Projects);
        }

    }
}