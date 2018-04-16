﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly2.Models;

namespace Vidly2.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customer
        public ActionResult Index()
        {
            var customers=GetCustomers();

            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            return View(customer);

        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1,Name = "Rob"},
                new Customer {Id = 2,Name = "Jerry"}

            };
        }
    }
}