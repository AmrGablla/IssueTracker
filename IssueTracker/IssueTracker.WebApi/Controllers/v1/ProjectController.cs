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
        /// <summary>
        /// Get all projects
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllProjectsParameter filter)
        {

            return Ok(await Mediator.Send(new GetAllProjectsQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber }));
        }

        /// <summary>
        /// Get project by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await Mediator.Send(new GetProjectByIdQuery { Id = id }));
        }

        /// <summary>
        /// Create Project
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(CreateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Update Project
        /// </summary>
        /// <param name="id"></param>
        /// <param name="command"></param>
        /// <returns></returns>
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
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await Mediator.Send(new DeleteProjectByIdCommand { Id = id }));
        }
    }
}
