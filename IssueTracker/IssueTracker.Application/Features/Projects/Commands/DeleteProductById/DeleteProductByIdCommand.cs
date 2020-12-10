using IssueTracker.Application.Exceptions;
using IssueTracker.Application.Interfaces.Repositories;
using IssueTracker.Application.Wrappers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Projects.Commands.DeleteProjectById
{
    public class DeleteProjectByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteProjectByIdCommandHandler : IRequestHandler<DeleteProjectByIdCommand, Response<int>>
        {
            private readonly IProjectRepositoryAsync _ProjectRepository;
            public DeleteProjectByIdCommandHandler(IProjectRepositoryAsync ProjectRepository)
            {
                _ProjectRepository = ProjectRepository;
            }
            public async Task<Response<int>> Handle(DeleteProjectByIdCommand command, CancellationToken cancellationToken)
            {
                var Project = await _ProjectRepository.GetByIdAsync(command.Id);
                if (Project == null) throw new ApiException($"Project Not Found.");
                await _ProjectRepository.DeleteAsync(Project);
                return new Response<int>(Project.Id);
            }
        }
    }
}
