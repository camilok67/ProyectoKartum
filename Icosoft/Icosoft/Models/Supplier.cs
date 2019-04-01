using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Icosoft.Models
{
    public class Supplier
    {
        [Key]
        public int idSuplier { get; set; }
        [Display(Name = "Proveedor")]
        public string SuplierName { get; set; }
        public ICollection<Supplie> Supplies { get; set; }

        //Agregando Ciudad
        public int IdCity { get; set; }
        public City City { get; set; }
    }


    public class MedidaTipo
    {
        [Key]
        public int IDMEDIDATIPO { get; set; }
        [Display(Name ="Tipo de Medida")]
        public string Nombre { get; set; }
        public ICollection<Supplie> Supplies { get; set; }
    }

    public class Supplie
    {
        [Key]
        public int idSupplie { get; set; }
        [Display(Name = "Nombre de Insumo")]
        public string SupplieName { get; set; }
        public int idSuplier { get; set; }
        public Supplier Supplier { get; set; }
        public ICollection<SupplieQuotation> SupplieQuotations { get; set; }
        public int IDMEDIDATIPO { get; set; }
        public MedidaTipo MedidaTipo { get; set; }
        

    }


    public class SupplieQuotation
    {
        [Key]
        public int idSupplieQuotation { get; set; }
        public double Quantity { get; set; }
        public double UnitValue { get; set; }
        public double TotalValue { get; set; }

        public int idSupplie { get; set; }
        public Supplie Supplies { get; set; }
        public int idDetail { get; set; }
        public Detail Details { get; set; }
    }

    
}