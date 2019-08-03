using AutoMapper;
using NGOWorld.Entity.CustomModel;
using NGOWorld.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGOWorld.Entity.Mapping
{
    public class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<tblDoctor, DoctorModel>().ReverseMap();
        }
    }
}
