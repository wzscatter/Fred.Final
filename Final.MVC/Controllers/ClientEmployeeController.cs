using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Final.MVC.Controllers
{
    public class ClientEmployeeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
