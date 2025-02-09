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
    public class WarehouseLocationController:Controller
    {
        private readonly IWarehouseLocationRepository _warehouseLocationRepository;
        private readonly IMapper _mapper;
        public WarehouseLocationController(IWarehouseLocationRepository warehouseLocationRepository)
        {
            _warehouseLocationRepository = warehouseLocationRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<WarehouseLocation>))]
        public IActionResult GetWarehouseLocations()
        {
            var warehouseLocations = _warehouseLocationRepository.GetWarehouseLocations();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(warehouseLocations);
        }
        [HttpGet("WarehouseLocationId")]
        [ProducesResponseType(200, Type = typeof(WarehouseLocation))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_warehouseLocationRepository.WarehouseLocationExists(categoryId))
                return NotFound();
            var WarehouseLocation = _warehouseLocationRepository.GetWarehouseLocation(categoryId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(WarehouseLocation);
        }
        [HttpGet("WarehouseLocationName")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryS(string name)
        {
            if (string.IsNullOrEmpty(name))
                return BadRequest("Category name must be provided.");

            var warehouseLocations = _warehouseLocationRepository.GetWarehouseLocation(name);

            if (warehouseLocations == null)
                return NotFound("Category not found.");

            return Ok(warehouseLocations);
        }
        [HttpGet("WarehouseLocationByWarehosue")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetWarehouseLocationByWarehouse(int id)
        {
            var w = _warehouseLocationRepository.GetWarehouseLocationByWarehouse(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(w);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateWarehouseLocation([FromBody] WarehouseLocationDto warehouseLocationDto)
        {
            if (warehouseLocationDto == null)
            {
                return BadRequest("WarehouseLocation data is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationMap = _mapper.Map<WarehouseLocation>(warehouseLocationDto);

            if (!_warehouseLocationRepository.CreateWarehouseLocation(locationMap))
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
        public IActionResult UpdateWarehouseLocation(int locationId,
            [FromBody] WarehouseLocationDto updatedLocation)
        {
            if (updatedLocation == null)
                return BadRequest(ModelState);

            if (locationId != updatedLocation.Id)
                return BadRequest(ModelState);

            if (!_warehouseLocationRepository.WarehouseLocationExists(locationId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var locationMap = _mapper.Map<WarehouseLocation>(updatedLocation);

            if (!_warehouseLocationRepository.UpdateWarehouseLocation(locationMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{WarehouseLocationId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteWarehouseLocation(int warehouseLocationId)
        {
            if (!_warehouseLocationRepository.WarehouseLocationExists(warehouseLocationId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var locationToDelete = _warehouseLocationRepository.GetWarehouseLocation(warehouseLocationId);

            if (!_warehouseLocationRepository.DeleteWarehouseLocation(locationToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
