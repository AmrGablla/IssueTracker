using IssueTracker.Application.Exceptions;
using IssueTracker.Application.Interfaces.Repositories;
using IssueTracker.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Projects.Commands.UpdateProject
{
    public class UpdateProjectCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
        public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Response<int>>
        {
            private readonly IProjectRepositoryAsync _ProjectRepository;
            public UpdateProjectCommandHandler(IProjectRepositoryAsync ProjectRepository)
            {
                _ProjectRepository = ProjectRepository;
            }
            public async Task<Response<int>> Handle(UpdateProjectCommand command, CancellationToken cancellationToken)
            {
                var Project = await _ProjectRepository.GetByIdAsync(command.Id);

                if (Project == null)
                {
                    throw new ApiException($"Project Not Found.");
                }
                else
                {
                    Project.Name = command.Name;
                    Project.Description = command.Description;
                    await _ProjectRepository.UpdateAsync(Project);
                    return new Response<int>(Project.Id);
                }
            }
        }
    }
}
