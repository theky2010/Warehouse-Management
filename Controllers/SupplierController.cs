using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WareHouseManagment.Dto;
using WareHouseManagment.Interfaces;
using WareHouseManagment.Models;
using WareHouseManagment.Repository;

namespace WareHouseManagment.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController:Controller
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IMapper _mapper;
        public SupplierController(ISupplierRepository supplierRepository, IMapper mapper)
        {
            _supplierRepository = supplierRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Supplier>))]
        public IActionResult GetProducts()
        {
            var suppliers = _supplierRepository.GetSuppliers();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(suppliers);
        }
        [HttpGet("SupplierId")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int supplierId)
        {
            if (!_supplierRepository.SupplierExists(supplierId))
                return NotFound();

            var supplier = _supplierRepository.GetSupplier(supplierId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(supplier);
        }
        [HttpGet("SupplierName")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(string supplierName)
        {
            if (string.IsNullOrEmpty(supplierName))
                return BadRequest("Product name must be provided.");

            var supplier = _supplierRepository.GetSupplier(supplierName);

            if (supplier == null)
                return NotFound("Product not found.");

            return Ok(supplier);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] SupplierDto supplierDto)
        {
            if (supplierDto == null)
            {
                return BadRequest("Supplier data is null.");
            }

            var supplier = _supplierRepository.GetSupplierTrimToUpper(supplierDto);

            if (supplier != null)
            {
                ModelState.AddModelError("", "Supplier already exists");
                return StatusCode(422, ModelState);
            }


            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplierMap = _mapper.Map<Supplier>(supplierDto);

            if (!_supplierRepository.CreateSupplier(supplierMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{supplierId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateSupplier(int supplierId, [FromBody] SupplierDto updatedSupplier)
        {
            if (updatedSupplier == null)
                return BadRequest(ModelState);

            if (supplierId != updatedSupplier.SupplierId)
                return BadRequest(ModelState);

            if (!_supplierRepository.SupplierExists(supplierId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var supplierMap = _mapper.Map<Supplier>(updatedSupplier);

            if (!_supplierRepository.UpdateSupplier(supplierMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{supplierId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteSupplier(int supplierId)
        {
            if (!_supplierRepository.SupplierExists(supplierId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var supplierToDelete = _supplierRepository.GetSupplier(supplierId);

            if (!_supplierRepository.DeleteSupplier(supplierToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
