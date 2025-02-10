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
    [Route("api/[controller]")]
    public class InventoryController: ControllerBase
    {
        private readonly IInventoryRepository   _inventoryRepository;
        private readonly IMapper _mapper;
        public InventoryController(IInventoryRepository inventoryRepository,IMapper mapper)
        {
            _inventoryRepository = inventoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Inventory>))]
        public IActionResult GetInventories()
        {
            var i = _inventoryRepository.GetInventories();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }

        [HttpGet("InventoryId")]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetProduct(int id)
        {
            if (!_inventoryRepository.InventoryExists(id))
                return NotFound();

            var i = _inventoryRepository.GetInventory(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }

        [HttpGet("InventoryByProduct")]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetInventoryByProduct(int id)
        {
            var i = _inventoryRepository.GetInventoryByProduct(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }

        [HttpGet("InventoryByLocation")]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetInventoryByLocation(int id)
        {
            var i = _inventoryRepository.GetInventoryByLocation(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] InventoryDto inventoryDto)
        {
            if (inventoryDto == null)
            {
                return BadRequest("Inventory data is null.");
            }          

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inventoryMap = _mapper.Map<Inventory>(inventoryDto);

            if (!_inventoryRepository.CreateInventory(inventoryMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{inventoryId}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateInventory(int inventoryId,
                [FromBody] InventoryDto updatedInventory)
        {
            if (updatedInventory == null)
                return BadRequest(ModelState);

            if (inventoryId != updatedInventory.Id)
                return BadRequest(ModelState);

            if (!_inventoryRepository.InventoryExists(inventoryId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var inventoryMap = _mapper.Map<Inventory>(updatedInventory);

            if (!_inventoryRepository.UpdateInventory(inventoryMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{inventoryId}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteInventory(int inventoryId)
        {
            if (!_inventoryRepository.InventoryExists(inventoryId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inventoryToDelete = _inventoryRepository.GetInventory(inventoryId);

            if (!_inventoryRepository.DeleteInventory(inventoryToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
