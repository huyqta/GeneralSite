using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EntityModel.Entity
{
    public class Category
    {
        public Category()
        {
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int ParentId { get; set; }

        public string Description { get; set; }
    }
}
