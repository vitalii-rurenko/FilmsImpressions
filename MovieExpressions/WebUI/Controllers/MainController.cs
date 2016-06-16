using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DAL.Entities;
using DAL.IMDBScrapper;
using System.Drawing;
using System.IO;

namespace WebUI.Controllers
{
    public class MainController : Controller
    {
        public DALManager dal;
        public MainController()
        {
            dal = new DALManager();
        }

        // GET: Main
        [HttpGet]
        public ActionResult Index()
        {
            List<Film> movies = dal.GetAllMovies();
            return View(movies);
        }

        //POST: Main
        [HttpPost]
        public ActionResult Index(string movieName )
        {
            if(movieName != null && movieName != "")
            dal.AddMovie(new Film(movieName));
            return RedirectToAction("Index","Main");
        }

        [HttpGet]
        public ViewResult AboutFilm(int id)
        {
            Film movie = dal.GetFilm(id);
            return View(movie);
        }
        [HttpPost]
        public ActionResult AboutFilm(string authorName, string commentary, Film movie)
        {
            Film commentedFilm = dal.GetFilm(movie.ID);
            Comment comm = new Comment
            {
                Author = authorName,
                Text = commentary,
                Time = DateTime.Now,
                Film = commentedFilm
            };
            commentedFilm.Comments.Add(comm);
            dal.UpdateDb();
            return RedirectToAction("Index");
        }

        public string DropDb()
        {
            return dal.DropDatabase().ToString();
        }

        
        public FileResult GetImage(int id)
        {
            byte[] imgByteArr = dal.GetFilm(id).Poster;
            return File(imgByteArr, "image/jpeg");
        }

    }
}