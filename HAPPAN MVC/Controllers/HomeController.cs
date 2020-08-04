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



        public IActionResult Index()
        {
            var result = hAPPAN_MVC_AuthDBContext.Projects.ToList();
            return View(result);
        }
    }
}
