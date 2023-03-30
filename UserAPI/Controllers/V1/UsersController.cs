using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserAPI.Mappers;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUsersService _service;
        private readonly UserMapper _mapper;

        public UsersController(IUsersService service, UserMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateUser([FromBody] UserModel model)
        {
            if (model == null)
                return BadRequest();

            var entity = _mapper.UserModelToEntity(model);
            var isSuccess = await _service.CreateUserAsync(entity);

            if (!isSuccess)
                return BadRequest("Unable to save data! Please try again later.");

            return CreatedAtAction(nameof(GetUser), new { entity.Id }, entity);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUser(int id)
        {
            var entity = await _service.GetUserAsync(id);
            
            if (entity == null)
                return NotFound();

            var model = _mapper.UserEntityToModel(entity);
            return Ok(model);
        }
    }
}