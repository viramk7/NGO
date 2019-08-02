using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NGOWorld.Data.Entities
{
    public class tblDoctor : Entity<int>
    {
        [Required]
        [MaxLength(50)]
        public string DoctorName { get; set; }

        public string Speciality { get; set; }

        public string Hospital { get; set; }
    }
}
