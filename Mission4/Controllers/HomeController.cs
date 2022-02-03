using Mission4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private NewMovieContext blahContext { get; set; }

        //Constructor
        public HomeController(ILogger<HomeController> logger, NewMovieContext someName)
        {
            _logger = logger;
            blahContext = someName;
        }

        //Home Page
        public IActionResult Index()
        {
            return View();
        }

        //Submission confirmation page
        public IActionResult Confirmation()
        {
            return View(TESTINGHERETESTINGHERETESTINGHERETESTINGHERETESTINGHERETESTINGHERETESTINGHERE);
        }

        // My Podcasts page
        public IActionResult MyPodcasts()
        {
            return View();
        }
        // Display page for New Movie Form
        [HttpGet]
        public IActionResult NewMovie()
        {
            return View();
        }

        //Posting form information page
        [HttpPost]
        public IActionResult NewMovie(MovieResponse mr)
        {
            //writing to sql database and saving
            blahContext.Add(mr);
            blahContext.SaveChanges();

            return View("Confirmation", mr);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
