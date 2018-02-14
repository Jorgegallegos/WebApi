using AutoMapper;
using MajeBug.Domain;
using MajeBug.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MajeBug.WebApi.Helpers
{
    public class MapperHelper
    {
        internal static IMapper mapper;

        static MapperHelper()
        {
            var config = new MapperConfiguration(x => {
                x.CreateMap<Bug, BugApi>().ReverseMap();
                x.CreateMap<User, UserApi>().ReverseMap();
                x.CreateMap<Bug, CreateBugApi>().ReverseMap();
            });
            mapper = config.CreateMapper();
        }

        public static T Map<T>(object source) where T:class
        {
            return mapper.Map<T>(source);
        }
    }
}