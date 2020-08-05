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
using HAPPAN_MVC.Models;
using HAPPAN_MVC.Data;

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
            var result = hAPPAN_MVC_AuthDBContext.Projects.ToList();
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
