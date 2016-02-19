using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsSite.Models
{
    class ExtraContent
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string contentPath { get; set; }
    }
}
