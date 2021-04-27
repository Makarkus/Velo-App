using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VeloAPP.Models
{
    public class PageInfo
    {
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
        public int TotalItems { get; set; }
        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / PageSize); }
        }
    }
    public class IndexViewModel
    {
        public IEnumerable<Detail> Details { get; set; }
        public IEnumerable<Koleso> Kolesos { get; set; }
        public IEnumerable<Rama> Ramas { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
