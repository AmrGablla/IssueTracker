using IssueTracker.Application.Features.Products.Commands.CreateProduct;
using IssueTracker.Application.Features.Products.Queries.GetAllProducts;
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
            CreateMap<Product, GetAllProductsViewModel>().ReverseMap();
            CreateMap<CreateProductCommand, Product>();
            CreateMap<GetAllProductsQuery, GetAllProductsParameter>();
        }
    }
}
