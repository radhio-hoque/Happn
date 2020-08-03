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
        private readonly HAPPAN_MVC_AuthDBContext hAPPAN_MVC_AuthDBContext;

        public HomeController(HAPPAN_MVC_AuthDBContext hAPPAN_MVC_AuthDBContext)
        {
            this.hAPPAN_MVC_AuthDBContext = hAPPAN_MVC_AuthDBContext;
        }

        public IEnumerable<Project> GetProjects { get; set; }

        public IActionResult Index()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
