using IssueTracker.Application.Features.Projects.Commands.CreateProject;
using IssueTracker.Application.Features.Projects.Queries.GetAllProjects;
using AutoMapper;
using IssueTracker.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace IssueTracker.Application.Mappings
{
    public class GeneralProfile : Profile
    {
        public GeneralProfile()
        {
            CreateMap<Project, GetAllProjectsViewModel>().ReverseMap();
            CreateMap<CreateProjectCommand, Project>();
            CreateMap<GetAllProjectsQuery, GetAllProjectsParameter>();
        }
    }
}
