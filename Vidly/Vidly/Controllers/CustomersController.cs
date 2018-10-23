using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.DAL;
using Vidly.Models;
using Vidly.ViewModels;
using System.Data.Entity;
using System.Data.Entity.Validation;


namespace Vidly.Controllers
{
      

    public class CustomersController : Controller
    {
        private AppContext _context;

        public CustomersController() {
            _context = new AppContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // New Customer
        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newVm = new CustomerFormViewModel()
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",newVm);
        }

        // Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    var vm = new CustomerFormViewModel()
                    {
                        Customer = customer,
                        MembershipTypes = _context.MembershipTypes.ToList()
                    };
                    return View("CustomerForm", vm);
                }


                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);

                }
                else
                {
                    var customerdb = _context.Customers.Single(x => x.Id == customer.Id);
                    // Mapper.map ()

                    customerdb.Name = customer.Name;
                    customerdb.BirthdayDate = customer.BirthdayDate;
                    customerdb.IsSubscribedtoNewsLetter = customer.IsSubscribedtoNewsLetter;
                    customerdb.MembershipTypeId = customer.MembershipTypeId;

                }
                _context.SaveChanges();
            }
            catch (DbEntityValidationException e )
            {

                Console.WriteLine(e);
            }           

           
            return RedirectToAction("Index", "Customers");
        }



        // GET: Customers
        public ActionResult Index()
        {
            return View();
        }

        // GET: Customers
        public ActionResult Details(int Id)
        {
            
                var customer =_context.Customers.Include(c => c.MembershipType).SingleOrDefault(x => x.Id == Id);
                if (customer == null)
                    return HttpNotFound();
                return View(customer);
           
            
        }

        // GET: Customers
        public ActionResult Edit(int Id)
        {

            var customer = _context.Customers.SingleOrDefault(x => x.Id == Id);
            if (customer == null)
                return HttpNotFound();

            var vm = new CustomerFormViewModel()
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", vm);


        }
    }
}