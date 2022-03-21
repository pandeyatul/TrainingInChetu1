using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TrainingInChetu.Models;
using TrainingInChetu.Models.ViewModels;

namespace TrainingInChetu.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext operation;

        public HomeController(ApplicationDbContext customerdb )
        {
            operation = customerdb;
        }

        public IActionResult Index()
        {
            /*var info = operation.customers.ToList();*/
            var info = (from c in operation.customers
                       join
                       loca in operation.Locations
                       on c.Location.Id equals loca.Id
                       select new CustomerViewModel()
                       {
                           Id=c.Id,
                           Name=c.Name,
                           Contactno = c.Contactno,
                           EmailId=c.EmailId,
                           Address=c.Address,
                           Location=loca.City
                       }).ToList();
            return View(info);
        }
        public IActionResult Delete(int id)
        {
            var cust = operation.customers.SingleOrDefault(e=>e.Id==id);
            operation.customers.Remove(cust);
            operation.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult edit(int id)
        {
            var custm = operation.customers.SingleOrDefault(e => e.Id == id);
            if(custm!=null)
            {
                ViewBag.location = operation.Locations.ToList();
                var model = new CustomerUpdateViewModel()
                {
                    Id=custm.Id,
                    Name=custm.Name,
                    Contactno=custm.Contactno,
                    EmailId=custm.EmailId,
                    Address=custm.Address,
                    Location=custm.Location.City
                };
                return View(model);
            }
            else
            {
                return RedirectToAction("Index");
            }
            
            //var info = (from c in operation.customers
            //            join
            //            loca in operation.Locations
            //            on c.Location.Id equals loca.Id
                        
            //            select new CustomerViewModel()
            //            {
            //                Id = c.Id,
            //                Name = c.Name,
            //                Contactno = c.Contactno,
            //                EmailId = c.EmailId,
            //                Address = c.Address,
            //                Location = loca.City
            //            });
            //ViewBag.location = operation.Locations.ToList();
          

        }
        [HttpPost]
        public IActionResult edit(CustomerViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                var cust = operation.customers.SingleOrDefault(e=>e.Id==cvm.Id);
                cust.Name = cvm.Name;
                cust.Contactno = cvm.Contactno;
                cust.EmailId = cvm.EmailId;
                cust.Address = cvm.Address;
                cust.Location = operation.Locations.SingleOrDefault(e => e.Id == Convert.ToInt32(cvm.Location));

                operation.customers.Update(cust);
                operation.SaveChanges();
                return RedirectToAction("Index");
            } 
            return View(cvm);
        }
        public IActionResult Create()
        {
            ViewBag.location = operation.Locations.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(CustomerViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                var customer = new Customer()
                {
                    Name = cvm.Name,
                    Contactno = cvm.Contactno,
                    EmailId = cvm.EmailId,
                    Address = cvm.Address,
                    Location = operation.Locations.SingleOrDefault(e => e.Id == Convert.ToInt32(cvm.Location))
                };
                operation.customers.Add(customer);
                operation.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cvm);
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Career()
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
