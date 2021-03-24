using FilmCollection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private FilmListContext context { get; set; }
        public HomeController(ILogger<HomeController> logger, FilmListContext flc)
        {
            _logger = logger;

            context = flc;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MyPodcasts()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AddFilm()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddFilm(Film newFilm)
        {
            if (ModelState.IsValid)
            { 
                //TempStorage.AddFilm(newFilm);
                //return View("Confirmation", newFilm);
                //return RedirectToAction("CurrentFilms");

                context.Films.Add(newFilm);
                context.SaveChanges();
            }
            
            return View();
            
        }

        public IActionResult CurrentFilms()
        {
            //return View(TempStorage.Films);
            return View(context.Films);
        }

        [HttpGet]
        public IActionResult Edits(int id)
        {
            //Show the film that they have clicked on, along with it's information 
            Film film = context.Films.Find(id);
            return View(film);
        }

        [HttpPost]
        public IActionResult Edits(Film film)
        {
            //If the edits meet the requirements of the different fields
            if (ModelState.IsValid)
            {
                //go find the movie that is being edited in the database and delete it, then upload this new edit as a movie
                var movie = context.Films.Where(m => m.FilmId == film.FilmId).FirstOrDefault();
                context.Films.Remove(movie);
                context.Films.Add(film);
                context.SaveChanges();

            }
            //When finished, show the list of films to confirm that it's happened successfuly
            return RedirectToAction("CurrentFilms");
        }

        public IActionResult Deletes(int id)
        {
            //this takes in the id of the film to delete, searches the database for that film and deletes it
            var movie = context.Films.Where(m => m.FilmId == id).FirstOrDefault();
            context.Films.Remove(movie);
            context.SaveChanges();
            return RedirectToAction("CurrentFilms");
        }
        public IActionResult Privacy()
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
