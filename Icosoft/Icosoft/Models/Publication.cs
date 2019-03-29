using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    // tabla tipos de publicaciones
    public class TypePublication
    {
        [Key]
        [Display(Name = "Tipo de Publicacion")]
        public int idTypePublication { get; set; }

        //Relacion entre Tipo. Publicacion y publicaciones
        public string TypePublications { get; set; }
        public ICollection<Publication> idPublications { get; set; }

    }

    //tabla publicaciones
    public class Publication
    {
        [Key]
        public int idPublication { get; set; }

        [Display(Name ="Nombre de la Publicación")]
        public int PublicationName { get; set; }

        [Display(Name = "Costo")]
        public decimal Cost { get; set; }

        [Display(Name = "Fecha de la publicación")]
        public DateTime PublicationDate { get; set; }

        [Display(Name = "Estado")]
        public string State { get; set; }

        [Display(Name = "Alto")]
        public double Height { get; set; }

        [Display(Name = "Ancho")]
        public double Width { get; set; }

        [Display(Name = "Profundidad")]
        public double Depth { get; set; }

        //Relacion entre Tipo. Publicacion y publicaciones
        public virtual TypePublication TypePublications { get; set; }

        //Relacion entre imagenes y publicaciones
        public virtual PublicationImage PublicationImages { get; set; }

        //Relacion entre intermedia Tipo. Medidas y publicaciones
        public virtual MediMeasurementsPublication MediMeasurementsPublications { get; set; }
    }

    public class Measure
    {
        [Key]
        public int idMeasure { get; set; }

        [Display(Name = "Medida Altura")]
        public string MeasureHeight { get; set; }

        [Display(Name = "Medida Ancho")]
        public string MeasureWidth { get; set; }

        [Display(Name = "Medida Profundidad")]
        public string DepthMeasurement { get; set; }

        [Display(Name = "Descripción")]
        public string Description { get; set; }

        //Relacion entre intermedia Tipo. Medidas y medidas
        public virtual MediMeasurementsPublication MediMeasurementsPublications { get; set; }
    }


    public class ImagePublication
    {
        [Key]
        public int idImage { get; set; }

        [Display(Name = "Imagen")]
        public string Image { get; set; }

        //Relacion entre imagnes y publicaciones
        public virtual PublicationImage PublicationImages { get; set; }
    }


    //Tabla entre intermedia imagenes  y publicaciones
    public class PublicationImage
    {
        [Key]
        public int idPublicationImage { get; set; }

        public int idImage { get; set; }

        public int idPublication { get; set; }

        public ICollection<Publication> Publications { get; set; }

        public ICollection<PublicationImage> PublicationImages { get; set; }
    }


    //Tabla entre intermedia tipo. medidas  y publicaciones
    public class MediMeasurementsPublication
    {
        [Key]
        public int idMediMeasurementsPublication { get; set; }

        public int idPublication { get; set; }

        public int idMeasure { get; set; }


        public ICollection<Publication>  Publications { get; set; }

        public ICollection<Measure> Measures { get; set; }

    }
}