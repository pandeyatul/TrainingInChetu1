using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TrainingInChetu.Models;
using System.Threading.Tasks;

namespace TrainingInChetu.Controllers
{
    public class CustomersController : Controller
    {
        private readonly ApplicationDbContext showDetails;
        public CustomersController(ApplicationDbContext db)
        {
            showDetails = db;
        }
        public IActionResult Index()
        {
            var ld = showDetails.Locations.ToList();

            return View(ld);
        }
        public IActionResult CustomersList(int x)
        {
            var list = showDetails.customers.Where(e => e.Location.Id == x);
            return View(list);
        }
    }
}
