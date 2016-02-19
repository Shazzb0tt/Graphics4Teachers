using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsSite.Enum
{
    public enum Area
        {[Display(Name = "Freehand Sketching")]
        Freehand_sketching,
        [Display(Name = "2-D Instrumental Drawing")]
        DDDrawing,
        [Display(Name = "3-D Instrumental Drawing")]
        DDDDrawing, 
        [Display(Name = "Rendering")]
        Rendering, 
        [Display(Name="Computer Aided Drawing")]
        Computer_Aided_Drawing}
}
