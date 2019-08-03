using AutoMapper;
using NGOWorld.Data.Repository.Generic;
using NGOWorld.Entity.Entities;
using NGOWorld.Service.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGOWorld.Service.DoctorService
{
    public class DoctorService : EntityService<tblDoctor> , IDoctorService
    {
        public DoctorService(IRepository<tblDoctor> repository, IMapper mapper) : base(repository, mapper)
        {
        }
    }
}
