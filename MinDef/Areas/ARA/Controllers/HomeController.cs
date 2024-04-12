using Microsoft.AspNetCore.Mvc;
using MinDef.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MinDef.Areas.ARA.Controllers
{
    [Area("ARA")]
    public class HomeController : MinDefBaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
