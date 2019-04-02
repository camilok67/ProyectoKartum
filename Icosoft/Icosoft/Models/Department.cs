using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class Department
    {
        [Key]
        public int IdDepartment { get; set; }
        public string DepartmentName { get; set; }
        public virtual ICollection<City> Cities { get; set; }
    }

    public class City
    {
        [Key]
        public int IdCity { get; set; }
        public string CityName { get; set; }
        public int IdDepartment { get; set; }
        public Department Department { get; set; }
        public virtual ICollection<Supplier> Suppliers { get; set; }
    }
}