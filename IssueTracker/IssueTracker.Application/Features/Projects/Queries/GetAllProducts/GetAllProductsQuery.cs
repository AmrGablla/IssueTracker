using IssueTracker.Application.Filters;
using IssueTracker.Application.Interfaces.Repositories;
using IssueTracker.Application.Wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Projects.Queries.GetAllProjects
{
    public class GetAllProjectsQuery : IRequest<PagedResponse<IEnumerable<GetAllProjectsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjectsQuery, PagedResponse<IEnumerable<GetAllProjectsViewModel>>>
    {
        private readonly IProjectRepositoryAsync _ProjectRepository;
        private readonly IMapper _mapper;
        public GetAllProjectsQueryHandler(IProjectRepositoryAsync ProjectRepository, IMapper mapper)
        {
            _ProjectRepository = ProjectRepository;
            _mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllProjectsViewModel>>> Handle(GetAllProjectsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllProjectsParameter>(request);
            var Project = await _ProjectRepository.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var ProjectViewModel = _mapper.Map<IEnumerable<GetAllProjectsViewModel>>(Project);
            return new PagedResponse<IEnumerable<GetAllProjectsViewModel>>(ProjectViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
