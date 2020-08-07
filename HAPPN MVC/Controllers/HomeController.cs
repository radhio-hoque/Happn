using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using HAPPAN_MVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using HAPPAN_MVC.Data;
using HAPPAN_MVC.Models.VMModels;

namespace HAPPAN_MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly HAPPANDBContext hAPPAN_MVC_AuthDBContext;

        

        public HomeController(HAPPANDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }


        // GET: Project
        public IActionResult Index()
        {
            var projectRepo = hAPPAN_MVC_AuthDBContext.Projects.ToList();
            //var result = projectRepo.Select(s=> new VMProjects {
            //    ProjectId = s.ProjectId,
            //    ProjectName = s.ProjectName,
            //    ProjectProgress = (s.Tasks.Count()*100)-(s.Tasks.Select(l=> l.PercentageOfProject).Sum()),
            //    Task = s.Tasks.Select(ss=> new VMTask { 
            //        TaskId = ss.TaskId,
            //        TaskName = ss.TaskName,
            //        Progress = ss.PercentageOfProject
            //    }).ToList()
            //}).ToList();
            var taskRepo = hAPPAN_MVC_AuthDBContext.Tasks.ToList();
            var result = new List<VMProjects>();
            foreach (var s in projectRepo)
            {
                var d = new VMProjects();
                d.ProjectId = s.ProjectId;
                d.ProjectName = s.ProjectName;
                d.Status = s.Status;
                d.ProjectProgress = ((taskRepo.Where(w => w.ProjectId == s.ProjectId).Select(l => l.PercentageOfProject).Sum() * 100)/ (taskRepo.Where(w => w.ProjectId == s.ProjectId).Count() * 100)) ;
                d.Task = taskRepo.Where(w => w.ProjectId == s.ProjectId).Select(ss => new VMTask
                {
                    TaskId = ss.TaskId,
                    TaskName = ss.TaskName,
                    Progress = ss.PercentageOfProject
                }).ToList();
                result.Add(d);
            }

            return View(result);
        }

        // GET: Project/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var project = await hAPPAN_MVC_AuthDBContext.Projects.FindAsync(id);
            hAPPAN_MVC_AuthDBContext.Projects.Remove(project);
            await hAPPAN_MVC_AuthDBContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
