using Microsoft.AspNetCore.Mvc;
using DotNetNote.Models;
using System;
using System.Collections.Generic;

namespace DotNetNote.Controllers
{
    public class MovieListController : Controller
    {
        public IActionResult Index()
        {
            List<MovieViewModel> vms = new List<MovieViewModel>() {
                new MovieViewModel { Id = 1, Title = "명량", CreationData = new DateTime(2014, 1, 1) },
                new MovieViewModel { Id = 2, Title = "실미도", CreationData = new DateTime(2013, 1, 1) },
                new MovieViewModel { Id = 3, Title = "베테랑", CreationData = new DateTime(2015, 1, 1) },
            };

            return View(vms);
        }
    }
}