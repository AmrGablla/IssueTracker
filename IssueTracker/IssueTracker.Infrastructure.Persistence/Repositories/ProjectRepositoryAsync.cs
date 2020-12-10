using IssueTracker.Application.Interfaces.Repositories;
using IssueTracker.Domain.Entities;
using IssueTracker.Infrastructure.Persistence.Contexts;
using IssueTracker.Infrastructure.Persistence.Repository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace IssueTracker.Infrastructure.Persistence.Repositories
{
    public class ProjectRepositoryAsync : GenericRepositoryAsync<Project>, IProjectRepositoryAsync
    {
        private readonly DbSet<Project> _Projects;

        public ProjectRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _Projects = dbContext.Set<Project>();
        } 
    }
}
