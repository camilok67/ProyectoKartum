using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class TypePublication
    {
        [Key]
        public int idTypePublication { get; set; }
        public string TypePublications { get; set; }
        public ICollection<Publication> idPublications { get; set; }

    }
    public class Publication
    {
        [Key]
        public int idPublication { get; set; }

        public int PublicationName { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public DateTime PublicationDate { get; set; }
        public string State { get; set; }
        public double Height { get; set; }
        public double Width { get; set; }
        public double Depth { get; set; }
        public string MeasureHeight { get; set; }
        public string MeasureWidth { get; set; }
        public string DepthMeasurement { get; set; }
        public int idTypePublication { get; set; }
        public TypePublication TypePublication { get; set; }
        public ICollection<PublicationImage> PublicationImages { get; set; }
    }

    public class ImagePublication
    {
        [Key]
        public int idImage { get; set; }
        public string Image { get; set; }
        public ICollection<PublicationImage> PublicationImages { get; set; }
    }

    public class PublicationImage
    {
        [Key]
        public int idPublicationImage { get; set; }

        public int idImage { get; set; }
        public int idPublication { get; set; }
        public TypePublication Publications { get; set; }
        public PublicationImage PublicationImages { get; set; }
    }
}