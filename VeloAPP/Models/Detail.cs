using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VeloAPP.Models
{
    public class Detail
    {
        [Required]
        public int DetailId { get; set; }
        [Required]
        [StringLength(50, MinimumLength =2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength =3)]
        public string Colour { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string Country { get; set; }

        public int RamaId { get; set; }
        public Rama Ramas { get; set; }
    }
}
