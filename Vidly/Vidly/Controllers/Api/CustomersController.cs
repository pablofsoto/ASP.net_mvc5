using AutoMapper;
using System;
using System.Linq;
using System.Net;
using System.Web.Http;
using Vidly.DAL;
using Vidly.Dtos;
using Vidly.Models;
using System.Data.Entity;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private AppContext _context;

        public CustomersController()
        {
            _context = new AppContext();
        }
        //Get /api/Customers
        public IHttpActionResult GetCustomers()
        {
            return Ok(_context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer,CustomerDto>));
        }

        //Get /api/Customers/1
        public IHttpActionResult GetCustomer(int Id)
        {
            var customer= _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == Id);
            if (customer == null)
                NotFound();

            return Ok(Mapper.Map < Customer,CustomerDto >(customer));
        }

        // Post /api/Customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto) {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);

            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id),customerDto);

        }

        // PUT /api/Customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int Id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerdb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerdb == null)
                return NotFound();

            Mapper.Map(customerDto, customerdb);


            _context.SaveChanges();

            return Ok();

        }

        // DELETE /api/Customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int Id)
        {
            
            var customerdb = _context.Customers.SingleOrDefault(c => c.Id == Id);
            if (customerdb == null)
                return NotFound();

            _context.Customers.Remove(customerdb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
