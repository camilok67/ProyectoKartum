using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Icosoft.Models
{
    public class DetailViews
    {
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

            public string Image { get; set; }

            [Display(Name = "Imagen de referencia")]
            public HttpPostedFileBase ImageFile { get; set; }

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


            [Display(Name = "Medida Altura")]
            [Required(ErrorMessage = "Debe Seleccionar la {0}")]
            public string MeasureHeight { get; set; }

            [Display(Name = "Medida Ancho")]
            [Required(ErrorMessage = "Debe Seleccionar la {0}")]
            public string MeasureWidth { get; set; }

            [Display(Name = "Medida Profundidad")]
            [Required(ErrorMessage = "Debe Seleccionar la {0}")]
            public string DepthMeasurement { get; set; }



    }
}