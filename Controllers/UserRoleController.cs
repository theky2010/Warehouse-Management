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
    public class UserRoleController: ControllerBase
    {
        private readonly IUserRoleRepository _userRoleRepository;
        private readonly IMapper _mapper;
        public UserRoleController(IUserRoleRepository userRoleRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRoleRepository = userRoleRepository;
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<UserRole>))]
        public IActionResult GetUserRoles()
        {
            var userroles = _mapper.Map<List<UserRoleDto>>(_userRoleRepository.GetUserRoles());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(userroles);
        }
        [HttpGet("UserRoleByRoleId")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetUserRoleByRoleId(int roleId)
        {
            if (!_userRoleRepository.RoleIdExists(roleId))
                return NotFound();

            var role = _mapper.Map<List<UserRoleDto>>(_userRoleRepository.GetUserRoleByRoleId(roleId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(role);
        }
        [HttpGet("UserRoleByUserId")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(400)]
        public IActionResult GetUserRoleByUserId(int userId)
        {
            if (!_userRoleRepository.UserIdExists(userId))
                return NotFound();

            var user = _mapper.Map<UserRoleDto>(_userRoleRepository.GetUserRoleByUserId(userId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(user);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProduct([FromBody] UserRoleDto userroleDto)
        {
            if (userroleDto == null)
            {
                return BadRequest("Product data is null.");
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var URMap = _mapper.Map<UserRole>(userroleDto);

            if (!_userRoleRepository.CreateUserRole(URMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
        [HttpPut("{userId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult UpdatePokemon(int userId,
            [FromBody] UserRoleDto updatedUserRole)
        {
            if (updatedUserRole == null)
                return BadRequest(ModelState);

            if (userId != updatedUserRole.UserId)
                return BadRequest(ModelState);

            if (!_userRoleRepository.UserIdExists(userId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest();

            var userMap = _mapper.Map<UserRole>(updatedUserRole);

            if (!_userRoleRepository.UpdateUserRole(userMap))
            {
                ModelState.AddModelError("", "Something went wrong updating");
                return StatusCode(500, ModelState);
            }

            return NoContent();
        }
        [HttpDelete("{userId}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteUserRole(int userId)
        {
            if (!_userRoleRepository.UserIdExists(userId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userroleToDelete = _userRoleRepository.GetUserRoleByUserId(userId);

            if (!_userRoleRepository.DeleteUserRole(userroleToDelete))
            {
                ModelState.AddModelError("", "Something went wrong deleting");
            }

            return NoContent();
        }
    }
}
