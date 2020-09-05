using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvertisementApi.DbModel;
using AdvertisementApi.Models;
using AutoMapper;

namespace AdvertisementApi.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AdvertisementModel, AdvertisementDbModel>();
        }
    }
}
