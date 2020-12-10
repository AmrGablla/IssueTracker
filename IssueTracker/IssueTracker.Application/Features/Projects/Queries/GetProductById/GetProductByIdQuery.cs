using IssueTracker.Application.Exceptions;
using IssueTracker.Application.Interfaces.Repositories;
using IssueTracker.Application.Wrappers;
using IssueTracker.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Projects.Queries.GetProjectById
{
    public class GetProjectByIdQuery : IRequest<Response<Project>>
    {
        public int Id { get; set; }
        public class GetProjectByIdQueryHandler : IRequestHandler<GetProjectByIdQuery, Response<Project>>
        {
            private readonly IProjectRepositoryAsync _ProjectRepository;
            public GetProjectByIdQueryHandler(IProjectRepositoryAsync ProjectRepository)
            {
                _ProjectRepository = ProjectRepository;
            }
            public async Task<Response<Project>> Handle(GetProjectByIdQuery query, CancellationToken cancellationToken)
            {
                var Project = await _ProjectRepository.GetByIdAsync(query.Id);
                if (Project == null) throw new ApiException($"Project Not Found.");
                return new Response<Project>(Project);
            }
        }
    }
}
