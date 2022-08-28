using BookStore_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore_App.Controllers
{
    public class HomeController : Controller
    {
        [ViewData]
        public string Title { get; set; }
        [ViewData]
        public BookModel Book { get; set; }
        public ViewResult Index()
        {
            Title = "Home";
            Book = new BookModel() { Id = 1, Author = "Mr Writer" };

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
