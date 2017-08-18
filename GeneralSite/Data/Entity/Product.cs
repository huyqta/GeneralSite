using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModel.Entity
{
    public class Product
    {
        public Product()
        {
        }

        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }
    }
}
