using IssueTracker.Application.Interfaces.Repositories;
using IssueTracker.Application.Wrappers;
using AutoMapper;
using IssueTracker.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace IssueTracker.Application.Features.Projects.Commands.CreateProject
{
    public partial class CreateProjectCommand : IRequest<Response<int>>
    {
        public string Name { get; set; }
        public string Barcode { get; set; }
        public string Description { get; set; }
        public decimal Rate { get; set; }
    }
    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Response<int>>
    {
        private readonly IProjectRepositoryAsync _ProjectRepository;
        private readonly IMapper _mapper;
        public CreateProjectCommandHandler(IProjectRepositoryAsync ProjectRepository, IMapper mapper)
        {
            _ProjectRepository = ProjectRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var Project = _mapper.Map<Project>(request);
            await _ProjectRepository.AddAsync(Project);
            return new Response<int>(Project.Id);
        }
    }
}
