using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using Vidly1.Models;
using Vidly1.Models.ViewModels;

namespace Vidly1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movie
        public ActionResult Random()
        {
            var movie = new Movie() { Name = "Shark" };
            var customers = new List<Customer>
            {
                new Customer { Name = "Taimoor Ali" },
                new Customer { Name = "Eman Ejaz" }
            };

            var viewModel = new RandomMovieViewModel
            {
                Movie = movie, 
                Customers = customers
            };
            //ViewData["Movie"] = movie;
            //ViewBag.Movie = movie; dont use these
            return View(viewModel);
            
            
            //  return View(movie);
            //return Content("My wrold");
            // return HttpNotFound();
            //return new EmptyResult();
            // Redirect to a certain route and pass arguments 
            //return RedirectToAction("Index" , "Home" , new { page = 1, sortBy = "name" } );
        }

        /*public ActionResult Edit (int id)
        {
            This is how you use parameters passed to an action 
            return Content( Convert.ToString(id+ 1) );
        }*/

        /*The actions parameters can be nullable.*/
        public ActionResult Index(int? pageIndex , string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";
            return Content(String.Format("Page Index is {0} , SortBy is {1}", pageIndex, sortBy));

        }

        //following is an example of custom attribute based route
        [Route("movies/released/{year}/{month:regex(\\d{2}):range(1 , 12)}")]
        public ActionResult ByReleaseDate(int year , int month)
        {
             
            return Content(String.Format("I am a custom route with year = {0} and month = {1}" , year , month));
        }
        
    }
}