using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ReviewAppMVC.Models
{
    public class Product : MediaEntity
    {
        public string Name { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public virtual List<Review> Reviews { get; set; } = new List<Review>();
    }
}
