using Microsoft.AspNetCore.Mvc;
using System.Net;
using UserAPI.Enums;
using UserAPI.Mappers;
using UserAPI.Models;
using UserAPI.Services;

namespace UserAPI.Controllers.V1
{
    [ApiController]
    [Route("api/v1/users/{userId:int}/[controller]")]
    public class SubscriptionsController : ControllerBase
    {
        private readonly ISubscriptionsService _service;
        private readonly SubscriptionMapper _mapper;

        public SubscriptionsController(ISubscriptionsService service, SubscriptionMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> CreateSubscription(int userId, [FromBody] SubscriptionModel model)
        {
            if (model == null)
                return BadRequest();

            var entity = _mapper.MapSubscriptionModelToEntity(model);
            var isSuccess = await _service.CreateSubscriptionAsync(userId, entity);

            if (!isSuccess)
                return BadRequest("Unable to save data! Please try again later.");

            return CreatedAtAction(nameof(GetSubscription), new { userId, subscriptionId = entity.Id }, entity);
        }

        [HttpGet("{subscriptionId:int}")]
        [ProducesResponseType(typeof(UserModel), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetSubscription(int userId, int subscriptionId)
        {
            var entity = await _service.GetSubscriptionAsync(userId, subscriptionId);

            if (entity == null)
                return NotFound();

            var model = _mapper.MapSubscriptionEntityToModel(entity);

            return Ok(model);
        }

        [HttpGet("~/api/v1/users/subscriptions/{type}")]
        [ProducesResponseType(typeof(IEnumerable<int>), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetUserIdsBySubscriptionType(ESubscriptionType type)
        {
            var userIds = await _service.GetUserIdsBySubscriptionTypeAsync(type);

            if (!userIds.Any())
                return NotFound();

            return Ok(userIds);
        }
    }
}
