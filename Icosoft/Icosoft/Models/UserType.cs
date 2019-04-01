using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class UserType
    {
        [Key]
        public int IDUserType { get; set; }
        [StringLength(15)]
        public string UserTypeName { get; set; }
        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }

    public class DocumentType
    {
        [Key]
        public int IDDocumentType { get; set; }
        [StringLength(25)]
        public string DocumentTypeName { get; set; }
        //public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

    }
}