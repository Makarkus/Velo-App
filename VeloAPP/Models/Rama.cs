using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace VeloAPP.Models
{
    public class Rama
    {
        [Required]
        public int RamaId { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [Range(1, 10)]
        public string Length { get; set; }
        [Required]
        public string Material { get; set; }
        [Required]
        public string Country { get; set; }

        public List<Detail> Details { get; set; }
        public List<Koleso> Kolesos { get; set; }
    }
}
