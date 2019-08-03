using AutoMapper;
using NGOWorld.Data.CustomModel;
using NGOWorld.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NGOWorld.CoreHelper
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<tblDoctor, DoctorModel>().ReverseMap();
        }
    }
}
