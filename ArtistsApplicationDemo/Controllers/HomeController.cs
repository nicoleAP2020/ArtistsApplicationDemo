using ArtistsApplicationDemo.Repositories;
using ArtistsApplicationDemo.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArtistsApplicationDemo.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly AlbumRepository _albumRepository;
        private readonly ArtistRepository _artistRepository;

        public HomeController()
        {
            _albumRepository = new AlbumRepository();
            _artistRepository = new ArtistRepository();
        }
        public ActionResult Index()
        {
            HomeViewModel viewModel = new HomeViewModel()
            {
                Artists = _artistRepository.GetAll().Take(4), // Do this on repository
                Albums = _albumRepository.GetAll().Take(4) // Do this on repository
            };
            return View(viewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult NavBar()
        {
            if (User.Identity.IsAuthenticated)
            {
                return PartialView("_LoggedInNavbar");
            }
            return PartialView("_NavBar");
        }
    }
}