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
    public class InboundTransactionController:Controller
    {
        private readonly IInboundTransactionRepository _inboundTransactionRepository;
        private readonly IMapper _mapper;
        public InboundTransactionController(IInboundTransactionRepository inboundTransactionRepository,IMapper mapper)
        {
            _inboundTransactionRepository = inboundTransactionRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InboundTransaction>))]
        public IActionResult GetInboundTransaction()
        {
            var i = _inboundTransactionRepository.GetInboundTransactions();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(i);
        }
        [HttpGet("InboundTransactionId")]
        [ProducesResponseType(200, Type = typeof(InboundTransaction))]
        [ProducesResponseType(400)]
        public IActionResult GetCategory(int id)
        {
            if (!_inboundTransactionRepository.IbTExists(id))
                return NotFound();
            var i = _inboundTransactionRepository.GetInboundTransaction(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpGet("InbByWarehouse")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetCategoryS(int id)
        {
            var i = _inboundTransactionRepository.GetInbByWarehouse(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateInboundTransaction([FromBody] InboundTransactionDto inboundDto)
        {
            if (inboundDto == null)
            {
                return BadRequest("InboundTransaction data is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inboundMap = _mapper.Map<InboundTransaction>(inboundDto);

            if (!_inboundTransactionRepository.CreateInboundTransaction(inboundMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{InboundTransactionId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateInboundTransaction(int inboundId,
            [FromBody] InboundTransactionDto updateInbound)
        {
            if (updateInbound == null)
                return BadRequest(ModelState);

            if (inboundId != updateInbound.Id)
                return BadRequest(ModelState);

            if (!_inboundTransactionRepository.IbTExists(inboundId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var inboundMap = _mapper.Map<InboundTransaction>(updateInbound);

            if (!_inboundTransactionRepository.UpdateInboundTransaction(inboundMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{InboundId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteInboundTransaction(int inboundId)
        {
            if (!_inboundTransactionRepository.IbTExists(inboundId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var inboundToDelete = _inboundTransactionRepository.GetInboundTransaction(inboundId);

            if (!_inboundTransactionRepository.DeleteInboundTransaction(inboundToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
