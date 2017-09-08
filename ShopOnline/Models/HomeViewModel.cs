using EntityModel;
using EntityModel.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopOnline.Models
{
    public class HomeViewModel
    {
        public List<Category> ListCategory { get; set; }

        public List<Product> ListProduct { get; set; }

        public Category ActiveCategory { get; set; }

        public Product ActiveProduct { get; set; }

        public int ActiveCategoryId { get; set; }
    }
}
