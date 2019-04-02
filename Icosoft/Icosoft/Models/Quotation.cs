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

        [Display(Name = "Fecha de realización")]
        [Required(ErrorMessage = "Debe Ingresar la {0}")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DateCompleted { get; set; }

        [Display(Name = "Cantidad")]
        [Required(ErrorMessage = "Debe Ingresar la {0}")]        
        public int Quantity { get; set; }

        [Display(Name = "Estado")]
        [Required(ErrorMessage = "Debe Ingresar el {0}")]
        [StringLength(10, ErrorMessage = "El {0} debe tener {1} a {2}", MinimumLength = 5)]
        public string State { get; set; }

        [Display(Name = "Tipo de cotización")]
        [Required(ErrorMessage = "Debes seleccionar el {0}")]
        [StringLength(20, ErrorMessage = "El {0} debe tener {1} a {2}", MinimumLength = 5)]
        public string TypeQuotation { get; set; }

        [Display(Name = "Imprevistos")]
        [Required(ErrorMessage = "Debe Ingresar los {0}")]
        [DisplayFormat(DataFormatString ="{0:p2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal incidentals { get; set; }

        [Display(Name = "Costo del transporte")]
        [Required(ErrorMessage = "Debe Ingresar el {0}")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public double Transport { get; set; }

        [Display(Name = "Total labor")]
        [Required(ErrorMessage = "Debe Ingresar {0}")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal TotalLabor { get; set; }

        [Display(Name = "Valor del cliente")]
        [Required(ErrorMessage = "Debe Ingresar el {0}")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal CustomerValue { get; set; }

        [Display(Name = "Costo Mano de obra")]
        [Required(ErrorMessage = "Debe Ingresar el {0}")]
        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = false)]
        [DataType(DataType.Currency)]
        public decimal TotalProduction { get; set; }

        public ICollection<Detail> Details { get; set; }
    }

    public class Detail
    {
        [Key]
        public int idDetail { get; set; }


        [Display(Name = "Altura")]
        [Required(ErrorMessage = "Debe Ingresar la {0}")]
        public double Height { get; set; }


        [Display(Name = "Ancho")]
        [Required(ErrorMessage = "Debe Ingresar el {0}")]
        public double Width { get; set; }


        [Display(Name = "Profundidad")]
        [Required(ErrorMessage = "Debe Ingresar la {0}")]
        public double Depth { get; set; }

        //[Display(Name = "Medida Altura")]
        //[Required(ErrorMessage = "Debe Seleccionar la {0}")]
        //[StringLength(15, ErrorMessage = "El {0} debe tener {1} a {2}", MinimumLength = 5)]
        //public string MeasureHeight { get; set; }

        //[Display(Name = "Medida Ancho")]
        //[Required(ErrorMessage = "Debe Seleccionar la {0}")]
        //[StringLength(15, ErrorMessage = "El {0} debe tener {1} a {2}", MinimumLength = 5)]
        //public string MeasureWidth { get; set; }

        //[Display(Name = "Medida Profundidad")]
        //[Required(ErrorMessage = "Debe Seleccionar la {0}")]
        //[StringLength(15, ErrorMessage = "El {0} debe tener {1} a {2}", MinimumLength = 5)]
        //public string DepthMeasurement { get; set; }


        public string Image { get; set; }

        [Display(Name = "Descripción admin")]
        [Required(ErrorMessage = "Debe Ingresar la {0}")]
        [StringLength(250, ErrorMessage = "El {0} debe tener {1} a {2}", MinimumLength = 15)]
        [DataType(DataType.MultilineText)]
        public string DescriptionAdmin { get; set; }

        [Display(Name = "Descripción usuario")]
        [Required(ErrorMessage = "Debe Ingresar la {0}")]
        [StringLength(250, ErrorMessage = "El {0} debe tener {1} a {2}", MinimumLength = 15)]
        [DataType(DataType.MultilineText)]
        public string DescriptionUser { get; set; }


        public virtual ICollection<DetailImageQuotation> DetailImageQuotation { get; set; }
        public virtual ICollection<SupplieQuotation> SupplieQuotations { get; set; }

    }


    public class ImagenQuotation
    {
        [Key]
        public int idImagenQuotation { get; set; }
        public string ImagenQuotations { get; set; }
        public ICollection<DetailImageQuotation> DetailImageQuotations { get; set; }

    }

    public class DetailImageQuotation
    {
        [Key]
        public int idDetailImageQuotation { get; set; }

        public int idImagenQuotation { get; set; }
        public ImagenQuotation ImagenQuotations { get; set; }    }

    
}