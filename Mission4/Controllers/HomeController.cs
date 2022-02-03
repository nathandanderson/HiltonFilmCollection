using Mission4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Mission4.Controllers
{
    public class HomeController : Controller
    {
        private NewMovieContext blahContext { get; set; }

        //Constructor
        public HomeController( NewMovieContext someName)
        {
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
            return View();
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
            ViewBag.Categories = blahContext.Categories.OrderBy(x => x.CategoryName).ToList();

            return View();
        }

        //Posting form information page
        [HttpPost]
        public IActionResult NewMovie(MovieResponse mr)
        {
            if (ModelState.IsValid)
            {   //writing to sql database and saving
                blahContext.Add(mr);
                blahContext.SaveChanges();
            }
            else //If Invalid
            {
                ViewBag.Categories = blahContext.Categories.OrderBy(x => x.CategoryName).ToList();

                return View(mr);
            }
            return View("Confirmation", mr);
        }

        //Rendering Movie List dynamically, and making sure to link the value of categories to the id

        [HttpGet]
        public IActionResult MovieList()
        {
            var movies = blahContext.Responses
                .Include(x => x.Category)
                .OrderBy(x => x.Title)
                .ToList();

            return View(movies);
        }
        // Rendering the edit page based on the item they selected on the previous page.
        [HttpGet]
        public IActionResult Edit(int movieid)
        {
            ViewBag.Categories = blahContext.Categories.OrderBy(x=>x.CategoryName).ToList();

            var movie = blahContext.Responses.Single(x => x.MovieID == movieid);

            return View("NewMovie", movie);
        }
        // Saving the edits they made on the edit page.
        [HttpPost]
        public IActionResult Edit(MovieResponse blah)
        {
            blahContext.Update(blah);
            blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }

        //Render the delete page for a given movie
        [HttpGet]
        public IActionResult Delete(int movieid)
        {
            var movie = blahContext.Responses.Single(x => x.MovieID == movieid);

            return View(movie);
        }

        //Actually delete the movie after asking for confirmation
        [HttpPost]
        public IActionResult Delete (MovieResponse mr)
        {
            blahContext.Responses.Remove(mr);
            blahContext.SaveChanges();

            return RedirectToAction("MovieList");
        }
    }
}
