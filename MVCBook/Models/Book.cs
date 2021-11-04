using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MVCBook.Models
{
    [Table("Book")]//EF-->DB

    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The Name field is required")]

        [Column(TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(50, ErrorMessage="The field Author must be a string with a maximum lenght of 50")]

        [Column(TypeName = "varchar")]
        public string Author { get; set; }

        [Range(100, 10000, ErrorMessage ="The field PagesNumber must be between 100 and 10000")]
        public int PagesNumber { get; set; }

        [Column(TypeName = "varchar")]
        public string Publisher { get; set; }

        [Column(TypeName = "varchar")]
        [RegularExpression(@"^\d{4}(\-|\/|\.)\d{1,2}\1\d{1,2}$", ErrorMessage = "The field PublicationDate must match the regular expression, por ejemplo: 2017-06-16")]
        public string PublicationDate { get; set; }

        [Column(TypeName = "varchar")]
        public string Content { get; set; }

        [Column(TypeName = "money")]
        public decimal Price { get; set; }

        [System.ComponentModel.DataAnnotations.Compare("Price", ErrorMessage ="'PriceConfirm' and 'Price' do not match")]
        public decimal PriceConfirm { get; set; }
    }
}