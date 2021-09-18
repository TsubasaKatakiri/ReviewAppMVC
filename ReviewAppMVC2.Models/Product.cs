using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewAppMVC2.Models
{
    public class Product : MediaEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Category { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();
    }
}
