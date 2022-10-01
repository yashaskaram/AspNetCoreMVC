using BookStore_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        [ViewData]                          //ViewData Attribute
        public string Title { get; set; } 

        [Route("~/")]
        public ViewResult Index()
        {
            Title = "Home";

            return View();
        }

        public ViewResult AboutUs()
        {
            Title = "About us";
            return View();
        }

        public ViewResult ContactUs()
        {
            Title = "Contact us";
            return View();
        }
    }
}
