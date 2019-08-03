using NGOWorld.Data.Repository.Generic;
using NGOWorld.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NGOWorld.Data.Repository.Doctor
{
    public class DoctorRepository : Repository<tblDoctor> , IDoctorRepository
    {
        public DoctorRepository(NGODBContext context)
           : base(context)
        {
            
        }
    }
}
