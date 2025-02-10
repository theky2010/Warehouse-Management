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
    public class OutboundTransactionController: ControllerBase
    {
        private readonly IOutboundTransactionRepository _outboundTransactionRepository;
        private readonly IMapper _mapper;
        public OutboundTransactionController(IOutboundTransactionRepository outboundTransactionRepository,IMapper mapper)
        {
            _outboundTransactionRepository = outboundTransactionRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutboundTransaction>))]
        public IActionResult GetOutboundTransactions()
        {
            var i = _outboundTransactionRepository.GetOutboundTransactions();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(i);
        }

        [HttpGet("OutbTransactionId")]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200, Type = typeof(OutboundTransaction))]
        [ProducesResponseType(400)]
        public IActionResult GetOutboundTransaction(int id)
        {
            var i = _outboundTransactionRepository.GetOutboundTransaction(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }

        [HttpGet("OutbTransactionByCustomer")]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200, Type = typeof(OutboundTransaction))]
        [ProducesResponseType(400)]
        public IActionResult GetOutboundTransactiobByCustomer(int id)
        {
            var i = _outboundTransactionRepository.GetOutbTransactionByCustomer(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpGet("OutbTransactionByWarehouse")]
        [Authorize(Roles = "Admin,Manager,Staff")]
        [ProducesResponseType(200,Type = typeof(OutboundTransaction))]
        [ProducesResponseType(400)]
        public IActionResult GetOutbTransactionByWarehouse(int id)
        {
            var i = _outboundTransactionRepository.GetOutbTransactionByWarehouse(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpPost]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOutbound([FromBody] OutboundTransactionDto outboundDto)
        {
            if (outboundDto == null)
            {
                return BadRequest("OutboundTransaction data is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var outboundMap = _mapper.Map<OutboundTransaction>(outboundDto);

            if (!_outboundTransactionRepository.CreateOutboundTransaction(outboundMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{OutboundTransactionId}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateOutbound(int outboundId,
                [FromBody] OutboundTransactionDto updatedOutbound)
        {
            if (updatedOutbound == null)
                return BadRequest(ModelState);

            if (outboundId != updatedOutbound.Id)
                return BadRequest(ModelState);

            if (!_outboundTransactionRepository.OutboundTransactionExists(outboundId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var outboundMap = _mapper.Map<OutboundTransaction>(updatedOutbound);

            if (!_outboundTransactionRepository.UpdateOutboundTransaction(outboundMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{OutboundTransactiobId}")]
        [Authorize(Roles = "Admin,Manager")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOutbound(int outboundId)
        {
            if (!_outboundTransactionRepository.OutboundTransactionExists(outboundId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var outboundToDelete = _outboundTransactionRepository.GetOutboundTransaction(outboundId);

            if (!_outboundTransactionRepository.DeleteOutboundTransaction(outboundToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
