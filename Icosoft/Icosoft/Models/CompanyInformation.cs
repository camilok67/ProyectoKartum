using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class CompanyInformation
    {
        [Key]
        public int idCompanyInformation { get; set; }

        [Display(Name = "Misión")]
        public string Mision { get; set; }

        [Display(Name = "Visión")]
        public string vision { get; set; }
    }
}