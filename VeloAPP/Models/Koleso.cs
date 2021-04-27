using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VeloAPP.Models
{
    public class Koleso
    {
        [Required]
        public int KolesoId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [Range(1,5)]
        public string Radius { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string Country { get; set; }

        public int RamaId { get; set; }
        public Rama Ramas { get; set; }
    }
}
