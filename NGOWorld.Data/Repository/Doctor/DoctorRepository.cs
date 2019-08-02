using NGOWorld.Data.Entities;
using NGOWorld.Data.Repository.Generic;
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
