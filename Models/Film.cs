using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FilmCollection.Models
{
    public class Film
    {
        [Key]
        [Required]
        public int FilmId { get; set; }

        [Required]
        public string Category { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        [Range(1850, 2021, ErrorMessage = "Year must be between 1850 and 2021")]
        public int Year { get; set; }

        [Required]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool? Edited { get; set; }

        public string LentTo { get; set; }

        [StringLength(25, MinimumLength = 0, ErrorMessage = "Notes must be less than 25 characters.")]
        public string Notes { get; set; }

    }
}
