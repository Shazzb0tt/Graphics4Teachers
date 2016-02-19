using GraphicsSite.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsSite.Models
{
    public class Video
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Year Level")]
        public Year YearLevel { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Area")]
        public Area Area { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Lesson Number")]
        public int LessonNumber { get; set; }

        [Display(Name = "Video URL")]
        public string videoPath { get; set; }

        [Display(Name = "Power Point")]
        public string PPPath { get; set; }

        [Display(Name = "Word")]
        public string WordPath { get; set; }

        [Display(Name = "Sketch Up")]
        public string SUPath { get; set; }
    }


}
