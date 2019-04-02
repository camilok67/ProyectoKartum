using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class Quotation
    {
        [Key]
        public int idQuotation { get; set; }
        public DateTime DateCompleted { get; set; }
        public int Quantity { get; set; }
        public string State { get; set; }
        public string TypeQuotation { get; set; }
        public double incidentals { get; set; }
        public double Transport { get; set; }
        public double TotalLabor { get; set; }
        public double CustomerValue { get; set; }
        public double TotalProduction { get; set; }

        public ICollection<Detail> Details { get; set; }
    }

    public class Detail
    {
        [Key]
        public int idDetail { get; set; }

        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public string MeasureHeight { get; set; }
        public string MeasureWidth { get; set; }
        public string DepthMeasurement { get; set; }
        public string DescriptionAdmin { get; set; }
        public string DescriptionUser { get; set; }
        public int idQuotation { get; set; }
        public Quotation Quotation { get; set; }
        public ICollection<DetailImageQuotation> DetailImageQuotation { get; set; }
    }

    public class ImagenQuotation
    {
        [Key]
        public int idImagenQuotation { get; set; }
        public string ImagenQuotations { get; set; }
        public ICollection<DetailImageQuotation> DetailImageQuotation { get; set; }

    }

    public class DetailImageQuotation
    {
        [Key]
        public int idDetailImageQuotation { get; set; }

        public int idImagenQuotation { get; set; }
        public int idDetail { get; set; }
        public Detail Detail { get; set; }
        public ImagenQuotation ImagenQuotations { get; set; }
    }
}