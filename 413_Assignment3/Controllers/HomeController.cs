using _413_Assignment3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace _413_Assignment3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Podcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Add_Film()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add_Film(ApplicationResponse appResponse)
        {
            Debug.WriteLine("Category:" + appResponse.Category);

            //Validate the model
            if (ModelState.IsValid)
            {
                // Dont store independance day
                if (appResponse.Title != "Independence Day")
                {
                    TempStorage.AddApplication(appResponse);
                } 
                // since indepencace day wasnt store, page will display differently
                return View("SubmittedForm", appResponse);

            }
            else
            {
                //List out the Validation Errors
                return View();
            }
        }

        public IActionResult Film_List()
        {
            return View(TempStorage.Applications);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
