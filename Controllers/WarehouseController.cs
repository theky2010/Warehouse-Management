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
    public class WarehouseController : Controller
    {
        private readonly IWarehouseRepository _warehouseRepository;
        private readonly IMapper _mapper;
        public WarehouseController(IWarehouseRepository warehouseRepository,IMapper mapper)
        {
            _warehouseRepository = warehouseRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Supplier>))]
        public IActionResult GetWarehouses()
        {
            var suppliers = _warehouseRepository.GetWarehouses();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(suppliers);
        }
        [HttpGet("WarehouseId")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetWarehouse(int warehouseId)
        {
            if (!_warehouseRepository.WarehouseExists(warehouseId))
                return NotFound();

            var warehouse = _warehouseRepository.GetWarehouse(warehouseId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(warehouse);
        }
        [HttpGet("WarehouseName")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetWarehouse(string warehouseName)
        {
            if (string.IsNullOrEmpty(warehouseName))
                return BadRequest("Warehouse name must be provided.");

            var warehouse = _warehouseRepository.GetWarehouse(warehouseName);

            if (warehouse == null)
                return NotFound("Product not found.");

            return Ok(warehouse);
        }

        [HttpGet("WarehouseLocationName")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetLocationWarehouse(string location)
        {
            if (string.IsNullOrEmpty(location))
                return BadRequest("Warehouse name must be provided.");

            var locationname = _warehouseRepository.GetLocationWarehouse(location);

            if (locationname == null)
                return NotFound("Warehouse not found.");

            return Ok(locationname);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] WarehouseDto warehouseDto)
        {
            if (warehouseDto == null)
            {
                return BadRequest("Warehouse data is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var warehouseMap = _mapper.Map<Warehouse>(warehouseDto);

            if (!_warehouseRepository.CreateWarehouse(warehouseMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{productId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateWarehouse(int warehouseId,
            [FromBody] WarehouseDto updatedWarehouse)
        {
            if (updatedWarehouse == null)
                return BadRequest(ModelState);

            if (warehouseId != updatedWarehouse.WarehouseId)
                return BadRequest(ModelState);

            if (!_warehouseRepository.WarehouseExists(warehouseId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var warehouseMap = _mapper.Map<Warehouse>(updatedWarehouse);

            if (!_warehouseRepository.UpdateWarehouse(warehouseMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{warehouseId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteWarehouse(int warehouseId)
        {
            if (!_warehouseRepository.WarehouseExists(warehouseId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var warehouseToDelete = _warehouseRepository.GetWarehouse(warehouseId);

            if (!_warehouseRepository.DeleteWarehouse(warehouseToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
