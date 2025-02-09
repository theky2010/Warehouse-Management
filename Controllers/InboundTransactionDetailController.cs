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
    public class InboundTransactionDetailController:Controller
    {
        private readonly IInboundTransactionDetailRepository _inboundTransactionDetailRepository;
        private readonly IMapper _mapper;
        public InboundTransactionDetailController(IInboundTransactionDetailRepository inboundTransactionDetailRepository, IMapper mapper)
        {
            _inboundTransactionDetailRepository = inboundTransactionDetailRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<InboundTransactionDetail>))]
        public IActionResult GetInboundTransactionDetailRepositories()
        {
            var i = _inboundTransactionDetailRepository.GetInbTDetails();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(i);
        }
        [HttpGet("InbTDetailByInbound")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetInbTDetailByInbound(int id)
        {
            var i = _inboundTransactionDetailRepository.GetInbTDetailByInbound(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpGet("InbTDetailByProduct")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public IActionResult GetInbTDetailByProduct(int id)
        {
            var i = _inboundTransactionDetailRepository.GetInbTDetailByProduct(id);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(i);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] InboundTransactionDetailDto itDetailDto)
        {
            if (itDetailDto == null)
            {
                return BadRequest("InboundTransactionDetail data is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var detailMap = _mapper.Map<InboundTransactionDetail>(itDetailDto);

            if (!_inboundTransactionDetailRepository.CreateInbTDetail(detailMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{InbTDetailId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdateInboundTransactionDetail(int detailId,
            [FromBody] InboundTransactionDetailDto updatedDetailDto)
        {
            if (updatedDetailDto == null)
                return BadRequest(ModelState);

            if (detailId != updatedDetailDto.Id)
                return BadRequest(ModelState);

            if (!_inboundTransactionDetailRepository.InbTDetailExists(detailId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var detailMap = _mapper.Map<InboundTransactionDetail>(updatedDetailDto);

            if (!_inboundTransactionDetailRepository.UpdateInbTDetail(detailMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }

        [HttpDelete("{InbTDetailId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteInboundTransactionDetail(int detailId)
        {
            if (!_inboundTransactionDetailRepository.InbTDetailExists(detailId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var detailToDelete = _inboundTransactionDetailRepository.GetInbTDetail(detailId);

            if (!_inboundTransactionDetailRepository.DeleteInbTDetail(detailToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
