using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace NGOWorld.Entity.Entities
{
    public class tblDoctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string DoctorName { get; set; }

        public string Speciality { get; set; }

        public string Hospital { get; set; }
    }
}
