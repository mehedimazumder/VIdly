using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movie
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        
        public Genre Genre { get; set; }
        [Required]
        [Display(Name = "Genre")]
        public byte GenreId { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime DateAdded { get; set; }

        [Column(TypeName = "datetime2")]
        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        [Display(Name = "Number in stocks")]
        [Range(1, Int32.MaxValue)]
        public byte NumberInStock { get; set; }

        public byte NumberAvailable { get; set; }


    }
}