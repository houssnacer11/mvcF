using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domaine
{
   public class Film
    {
        /// <summary>
        /// Id
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// Title
        /// </summary>
        [StringLength(60, MinimumLength = 3)]
        public string Titre { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        /// <summary>
        /// Out date
        /// </summary>
        //kènèt date   
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date de production")]
        public DateTime DateProd { get; set; }

        /// <summary>
        /// Image Name
        /// </summary>
        [DataType(DataType.ImageUrl), Display(Name = "Image")]
        public string ImageUrl { get; set; }

        /// <summary>
        /// Genre
        /// </summary>
        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [Required(ErrorMessage = "Ce champ est obligatoire")]
        [StringLength(30)]
        public string Genre { get; set; }

        [Range(1, 100)]
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$")]
        [StringLength(5)]
        public string Evaluation { get; set; }
        // foreign key       
        public int ProducteurId { get; set; } // ? nullable

        [ForeignKey("ProducteurId")]
        public virtual Producteur Productor { get; set; }




    }
}
