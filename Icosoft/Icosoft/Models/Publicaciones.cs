using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{

    public class TipoPublicacion
    {
        [Key]
        public int idTipoPublicacion { get; set; }
        public string Tipo_Publicacion { get; set; }
        public ICollection<Publicaciones> Publicaciones { get; set; }

    }
    public class Publicaciones
    {
        [Key]
        public int idPublicacion { get; set; }
        public int Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Costo { get; set; }
        public DateTime FechaPublicacion { get; set; }
        public string Estado { get; set; }
        public double Altura { get; set; }
        public double Ancho { get; set; }
        public double Profundidad { get; set; }
        public string MedidaAltura { get; set; }
        public string MedidaAncho { get; set; }
        public string MedidaProfundidad { get; set; }
        public int idtipoPublicacion { get; set; }
        public TipoPublicacion TipoPublicacion { get; set; }
        public ICollection<Publicacion_imagen> Publicaciones_imagenes { get; set; }
    }

    public class ImagenPublicacion
    {
        [Key]
        public int idImagen { get; set; }
        public string imagen { get; set; }
        public ICollection<Publicacion_imagen> Publicaciones_imagenes { get; set; }
    }

    public class Publicacion_imagen
    {
        public int idtipoPublicacion { get; set; }
        public TipoPublicacion TipoPublicacion { get; set; }
        public int idImagen { get; set; }
        public ImagenPublicacion MyProperty { get; set; }
    }




}