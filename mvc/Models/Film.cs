using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieCyrine.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        // [StringLength(maximumLength: 20, MinimumLength = 8)]
        [StringLength(60, MinimumLength = 3)]
        public string Titre { get; set; }
        [Display(Name = "Date de production")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime ReleaseDate { get; set; }

        /*[RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(30)]*/
        public string Genre { get; set; }
     
        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Prix { get; set; }

        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Avis { get; set; }

        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Producteur")]
        public int ProducteurId { get; set; } 
        public Producteur Producteur { get; set; }
        //dropdown liste
        public ICollection<Producteur> producteurrs { get; set; }
       public IEnumerable<SelectListItem> Genres { get; set; }
        public IEnumerable<SelectListItem> Producteurs { get; set; }
    }
}