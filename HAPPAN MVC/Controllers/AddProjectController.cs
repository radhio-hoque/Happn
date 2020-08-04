using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HAPPAN.Controllers
{
    public class AddProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}