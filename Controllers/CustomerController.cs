using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WareHouseManagment.Dto;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Repository;

namespace WareHouseManagment.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]
    public class CustomerController:ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Customer>))]
        public IActionResult GetCustomers()
        {
            var customers = _customerRepository.GetCustomers();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customers);
        }
        [HttpGet("CustomerId")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCustomer(int customerId)
        {
            if (!_customerRepository.CustomerExists(customerId))
                return NotFound();
            var customer = _customerRepository.GetCustomer(customerId);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(customer);
        }
        [HttpGet("customerName")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryS(string customerName)
        {
            if (string.IsNullOrEmpty(customerName))
                return BadRequest("customer name must be provided.");

            var customer = _customerRepository.GetCustomer(customerName);

            if (customer == null)
                return NotFound("Category not found.");

            return Ok(customer);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] CustomerDto customerDto)
        {
            if (customerDto == null)
            {
                return BadRequest("Product data is null.");
            }

            var customer = _customerRepository.GetCustomerTrimToUpper(customerDto);

            if (customer != null)
            {
                ModelState.AddModelError("", "Customer already exists");
                return StatusCode(422, ModelState);
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerMap = _mapper.Map<Customer>(customerDto);

            if (!_customerRepository.CreateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{customerId}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateCustomer(int customerId,
            [FromBody] CustomerDto updatedCustomer)
        {
            if (updatedCustomer == null)
                return BadRequest(ModelState);

            if (customerId != updatedCustomer.Id)
                return BadRequest(ModelState);

            if (!_customerRepository.CustomerExists(customerId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var customerMap = _mapper.Map<Customer>(updatedCustomer);

            if (!_customerRepository.UpdateCustomer(customerMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{customerId}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteCustomer(int customerId)
        {
            if (!_customerRepository.CustomerExists(customerId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customerToDelete = _customerRepository.GetCustomer(customerId);

            if (!_customerRepository.DeleteCustomer(customerToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
