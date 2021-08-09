using AutoMapper;
using GraphQL.Domain.DTOs;
using GraphQL.Infrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace GraphQL.Implementation
{
    public abstract class BaseService
    {
        protected IMapper _mapper;
        public BaseService()
        {
            _mapper = new Mapper(new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Company, CompanyDto>().ReverseMap();
                cfg.CreateMap<Employment, EmploymentDto>().ReverseMap();
            }));
        }
    }
}
