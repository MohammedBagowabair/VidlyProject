using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VidlyProject.Models;
using System.Data.Entity;
using VidlyProject.ViewModels;

namespace VidlyProject.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }

        public ActionResult New()
        {
            var membershiplist = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershiplist

            };
            return View("CustomerForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var customer=_context.Customers.SingleOrDefault(x => x.Id == id);

            var viewModel = new CustomerFormViewModel
            {
                Customers = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm",viewModel);
        }

        [HttpPost]
        public ActionResult Save(CustomerFormViewModel viewModel)
        {

            if(viewModel.Customers.Id == 0) 
            {
                _context.Customers.Add(viewModel.Customers);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == viewModel.Customers.Id);
                customerInDb.Name = viewModel.Customers.Name;
                customerInDb.Birthdate= viewModel.Customers.Birthdate;
                customerInDb.IsSubscribedToNewsLetter=viewModel.Customers.IsSubscribedToNewsLetter;
                customerInDb.MembershipTypeId = viewModel.Customers.MembershipTypeId;

            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }
        // GET: Customers
        public ActionResult Index()
        {
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();

            return View(customers);

        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

       
    }

}