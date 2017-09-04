using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityModel.Entity
{
    public class Article
    {
        public Article()
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public int Content { get; set; }

        [ForeignKey("ParentId")]
        public string AccountId { get; set; }

        public Account Account { get; set; }
    }
}
