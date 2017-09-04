using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using EntityModel.Entity;

namespace AdminSite.Models
{
    public class CategoryModel
    {
		public int Id { get; set; }
        [Required]
		public string Name { get; set; }

        public string ImageUrl { get; set; }

        public virtual ICollection<Category> ParentId { get; set; }

		public string Description { get; set; }
    }
}
