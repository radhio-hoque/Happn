using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HAPPAN.Controllers
{
    public class CurrentProject : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Project1()
        {
            ViewData["project1"] = "Bkash App";
            return View();
        }

        public IActionResult Project2()
        {
            ViewData["project2"] = "Pathao App";
            return View();
        }

        public IActionResult Project3()
        {
            ViewData["project3"] = "Nogad App";
            return View();
        }

        public IActionResult Project4()
        {
            ViewData["project4"] = "Sohoj App";
            return View();
        }

        public IActionResult Project5()
        {
            ViewData["project5"] = "Ubar App";
            return View();
        }
    }
}
