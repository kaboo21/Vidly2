using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        //call DB of the application
        private ApplicationDbContext _context;

        //assigning value to the _context in constructor
        public CustomersController()
        {
            _context=new ApplicationDbContext();
        }
        // GET: Customer
        public ActionResult Index()
        {
            var customers=_context.Customers.Include(c=>c.MembershipType).ToList();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            return View(customer);

        }

        
    }
}