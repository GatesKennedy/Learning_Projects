using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MoshMVC_Vidly.Models;

namespace MoshMVC_Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random 
        public ActionResult Random()
        {
            var shrek = new Movie() { Name = "Shrek!" };

            return View(shrek);
        }
    }
}
