using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mission4.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }
        [Required(ErrorMessage ="Please include the movie's Title")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please include who directed the movie")]
        public string Director { get; set; }
        [Required(ErrorMessage ="Please include the year the movie was released")]
        public int Year { get; set; }
        [Required(ErrorMessage = "Please select a category")]
        public int CategoryID { get; set; }
        public Category Category { get; set; }
        [Required(ErrorMessage ="Please include the MPAA Rating")]
        public string Rating { get; set; }
        [Required(ErrorMessage ="Please include whether or not this movie was edited")]
        public bool Edited { get; set; }
        public string LentTo { get; set; }
        [MaxLength(25)]
        public string Notes { get; set; }

    }
}
