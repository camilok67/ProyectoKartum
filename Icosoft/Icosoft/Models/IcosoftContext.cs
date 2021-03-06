﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class IcosoftContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public IcosoftContext() : base("name=IcosoftContext")
        {
        }

        public System.Data.Entity.DbSet<Icosoft.Models.Supplie> Supplies { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.Supplier> Suppliers { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.UserType> UserTypes { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.DocumentType> DocumentTypes { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.Quotation> Quotations { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.Publication> Publications { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.Detail> Details { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.MedidaTipo> MedidaTipoes { get; set; }

        public System.Data.Entity.DbSet<Icosoft.Models.City> Cities { get; set; }
    }
}
