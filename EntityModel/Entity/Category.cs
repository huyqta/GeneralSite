using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        public string ImageUrl { get; set; }

        public DateTime DateCRT { get; set; }

        [ForeignKey("ParentId")]
        public Category Parent { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
