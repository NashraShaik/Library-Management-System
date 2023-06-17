using System;
using System.ComponentModel.DataAnnotations;

namespace librarymanagementsystem.Models
{
    public class book
    {

        [Key]
        public int bookid { get; set; }
        public String booktitle { get; set; }
        public String bookauthor { get; set; }
        public String bookpublisher { get; set; }
        public int bookedition { get; set; }
        public int bookcost { get; set; }
    }
}