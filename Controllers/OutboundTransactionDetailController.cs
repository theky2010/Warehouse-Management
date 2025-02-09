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
    public class OutboundTransactionDetailController:Controller
    {
        private readonly IOutboundTransactionDetailRepository _outboundTransactionDetailRepository;
        private readonly IMapper _mapper;
        public OutboundTransactionDetailController (IOutboundTransactionDetailRepository outboundTransactionDetailRepository,IMapper mapper)
        {
            _outboundTransactionDetailRepository = outboundTransactionDetailRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<OutboundTransactionDetail>))]
        public IActionResult GetOutboundTransactionDetails()
        {
            var i = _outboundTransactionDetailRepository.GetOutboundTransactionDetails();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(i);
        }
        [HttpGet("OutbTDetailId")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetOutbTDetail(int id)
        {
            var i = _outboundTransactionDetailRepository.GetOutboundTransactionDetail(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpGet("OutbTDetailByOutbound")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetOutbTDetailByOutbound(int id)
        {
            var i = _outboundTransactionDetailRepository.GetOutbTDetailByOutbound(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpGet("OutbTDetailByWarehouse")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetOutbTDetailByWarehouse(int id)
        {
            var i = _outboundTransactionDetailRepository.GetOutbTDetailByWarehouse(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateOutboundTransactionDetail([FromBody] OutboundTransactionDetailDto outboundDto)
        {
            if (outboundDto == null)
            {
                return BadRequest("OutboundTransactionDetail data is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var outboundMap = _mapper.Map<OutboundTransactionDetail>(outboundDto);

            if (!_outboundTransactionDetailRepository.CreateOutboundTransactionDetail(outboundMap))
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
        public IActionResult UpdateOutboundDetail(int outboundId,
                [FromBody] OutboundTransactionDetailDto updatedOutboundDetail)
        {
            if (updatedOutboundDetail == null)
                return BadRequest(ModelState);

            if (outboundId != updatedOutboundDetail.Id)
                return BadRequest(ModelState);

            if (!_outboundTransactionDetailRepository.OutboundTransactionDetailExists(outboundId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var outboundDetailMap = _mapper.Map<OutboundTransactionDetail>(updatedOutboundDetail);

            if (!_outboundTransactionDetailRepository.UpdateOutboundTransactionDetail(outboundDetailMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{OutboundDetailId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteOutboundDetail(int outboundId)
        {
            if (!_outboundTransactionDetailRepository.OutboundTransactionDetailExists(outboundId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var outboundDetailToDelete = _outboundTransactionDetailRepository.GetOutboundTransactionDetail(outboundId);

            if (!_outboundTransactionDetailRepository.DeleteOutboundTransactionDetail(outboundDetailToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
