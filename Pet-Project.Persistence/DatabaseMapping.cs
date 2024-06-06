using AutoMapper;
using Pet_Project.Logic.Models;
using Pet_Project.Persistence.Entities;
using System;

namespace Pet_Project.Persistence
{
    public class DatabaseMapping : Profile
    {
        public DatabaseMapping() 
        {
            CreateMap<URLEntity, GeneratingURL>();
        }
    }
}
