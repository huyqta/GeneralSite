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

        public string ISBN { get; set; }

        public string Year { get; set; }

        public int Pages { get; set; }

        public string Language { get; set; }

        public int FileSize { get; set; }
        public string FileFormat { get; set; }
        public string ImageUrl { get; set; }
        public string DownloadLink { get; set; }
        public string MediaLink { get; set; }
        public string ImageThumb { get; set; }
        public string DateCRT { get; set; }
        public int DownloadCount { get; set; }
        public int ReadCount { get; set; }
        public int SearchCount { get; set; }
        public string Tag { get; set; }
        public int SubjectId { get; set; }

        [ForeignKey("SubjectId")]
        public Subject Subject { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
