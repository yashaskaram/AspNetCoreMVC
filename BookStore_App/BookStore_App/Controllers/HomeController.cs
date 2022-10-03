using BookStore_App.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace BookStore_App.Controllers
{
    [Route("[controller]/[action]")]
    public class HomeController : Controller
    {
        private readonly NewBookAlertConfig _newBookAlertConfiguration;

        public HomeController(IOptionsSnapshot<NewBookAlertConfig> newBookAlertConfiguration)
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Value;
        }

        [ViewData]                          //ViewData Attribute
        public string Title { get; set; } 

        [Route("~/")]
        public ViewResult Index()
        {
            bool isDisplay = _newBookAlertConfiguration.DisplayNewBookAlert;

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
