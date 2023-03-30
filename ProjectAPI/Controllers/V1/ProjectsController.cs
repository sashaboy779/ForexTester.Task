using Microsoft.AspNetCore.Mvc;
using ProjectAPI.Contracts.Requests;
using ProjectAPI.Contracts.Responses;
using ProjectAPI.Mappers;
using ProjectAPI.Services;
using System.Net;

namespace ProjectAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectsService _service;
        private readonly ProjectMapper _mapper;

        public ProjectsController(IProjectsService service, ProjectMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{id:length(24)}")]
        [ProducesResponseType(typeof(GetProjectResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Get(string id)
        {
            var project = await _service.GetAsync(id);

            if (project == null)
                return NotFound();

            var response = _mapper.MapProjectToResponse(project);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Create([FromBody] CreateProjectRequest createRequest)
        {
            if (createRequest == null)
                return BadRequest();

            var project = _mapper.MapRequestToProject(createRequest);
            await _service.CreateAsync(project);

            return NoContent();
        }

        [HttpPut("{id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Update(string id, UpdateProjectRequest updateRequest)
        {
            if (updateRequest == null)
                return BadRequest();

            var existingProject = await _service.GetAsync(id);
            if (existingProject == null)
                return NotFound();

            _mapper.MapRequestToProject(updateRequest, existingProject);
            var isSuccess = await _service.UpdateAsync(id, existingProject);

            if (!isSuccess)
                return BadRequest("Unable to save data! Please try again later.");

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> Delete(string id)
        {
            var existingProject = await _service.GetAsync(id);
            if (existingProject == null)
                return NotFound();

            await _service.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("indicators/mostused")]
        [ProducesResponseType(typeof(GetMostUsedIndicatorNamesResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NotFound)]
        public async Task<IActionResult> GetMostUsedIndicatorNames([FromQuery]int top = 3)
        {
            var result = await _service.GetMostUsedIndicatorNames(top);

            if (!result.Any())
                return NotFound();

            var response = new GetMostUsedIndicatorNamesResponse
            {
                Indicators = result.Select(r => new IndicatorUsage { Name = r.IndicatorName, Used = r.Count })
            };
            return Ok(response);
        }
    }
}
