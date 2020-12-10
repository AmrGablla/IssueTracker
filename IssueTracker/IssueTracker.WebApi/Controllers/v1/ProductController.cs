using System.Threading.Tasks;
using IssueTracker.Application.Features.Projects.Commands.CreateProject;
using IssueTracker.Application.Features.Projects.Commands.DeleteProjectById;
using IssueTracker.Application.Features.Projects.Commands.UpdateProject;
using IssueTracker.Application.Features.Projects.Queries.GetAllProjects;
using IssueTracker.Application.Features.Projects.Queries.GetProjectById;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace IssueTracker.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ProjectController : BaseApiController
    {
        // GET: api/<controller>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProjectsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllProjectsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProjectByIdQuery { Id = id }));
        }

        // POST api/<controller>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(int id, UpdateProjectCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await Mediator.Send(command));
        }


        /// <summary>
        /// Deletes a specific TodoItem.
        /// </summary>
        /// 
        /// <param name="id"></param>   
        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProjectByIdCommand { Id = id }));
        }
    }
}
