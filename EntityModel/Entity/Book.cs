using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EntityModel.Entity
{
    public class Book
    {
        public Book()
        {
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Publisher { get; set; }

        public int Description { get; set; }

        public string EpubUrl { get; set; }

        public string PdfUrl { get; set; }

        public string WordUrl { get; set; }

        public string PrcUrl { get; set; }

        public string ImageUrl { get; set; }
    }
}
