using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class Cotizacion
    {
        [Key]
        public int idCotizacion { get; set; }
        public DateTime FechaRealizada { get; set; }
        public int Cantidad { get; set; }
        public string Estado { get; set; }
        public string TipoCotizacion { get; set; }
        public double Imprevistos { get; set; }
        public double Transporte { get; set; }
        public double TotalManoObra { get; set; }
        public double ValorCliente { get; set; }
        public double TotalProduccion { get; set; }
    }

    public class Detalles
    {
        [Key]
        public int idDetalles { get; set; }
        public double Altura { get; set; }
        public double Ancho { get; set; }
        public double Profundidad { get; set; }
        public int MyProperty { get; set; }
        public string MedidaAltura { get; set; }
        public string MedidaAncho { get; set; }
        public string MedidaProfundidad { get; set; }
        public string DescripcionAdmin { get; set; }
        public string DescripcionUsuario { get; set; }
        public ICollection<DetallesImagenCotizacion> detallesImagenCotizacions { get; set; }
    }

    public class ImagenesCotizacion
    {
        [Key]
        public int idImagenCotizacion { get; set; }
        public string imagenCotizacion { get; set; }
        public ICollection<DetallesImagenCotizacion> detallesImagenCotizacions { get; set; }

    }

    public class DetallesImagenCotizacion
    {
        public int idImagenCotizacion { get; set; }
        public Detalles Detalles { get; set; }
        public int idDetalles { get; set; }
        public ImagenesCotizacion ImagenesCotizacion { get; set; }
    }
}