using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace NGOWorld.Entity.CustomModel
{
    public class DoctorModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Name = "Doctor Name")]
        [Required(ErrorMessage = "Doctor Name is required")]
        public string DoctorName { get; set; }

        [Display(Name = "Speciality")]
        public string Speciality { get; set; }

        [Display(Name = "Hospital Name")]
        [Required(ErrorMessage = "Hospital Name is required")]
        public string Hospital { get; set; }
    }
}
