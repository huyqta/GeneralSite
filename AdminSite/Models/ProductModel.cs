using EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace AdminSite.Models
{
    public class ProductModel
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }

        public string Name { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string Description { get; set; }

        public string UnitItem { get; set; }

        public Category Category { get; set; }
    }
}
