
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HitaRasDhara.Models
{

    public class UpcomingKathaViewModel
    {
        public List<UpcomingKathaItem> KathaFeed { get; set; }
    }


    public class UpcomingKathaItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int KathaId { get; set; }

        [Required]
        [Display(Name = "KathaTitle")]
        public string KathaTitle { get; set; }

        [Required]
        [Display(Name = "Dates")]
        public string Dates { get; set; }

        [Required]
        [Display(Name = "Timings")]
        public string Timings { get; set; }

        [Required]
        [Display(Name = "AddressLine1")]
        public string AddressLine1 { get; set; }

        [Required]
        [Display(Name = "AddressLine2")]
        public string AddressLine2 { get; set; }

        [Required]
        [Display(Name = "AddressLine3")]
        public string AddressLine3 { get; set; }

        [Required]
        [Display(Name = "LocationUrl")]
        public string LocationUrl { get; set; }

        [Required]
        [Display(Name = "GoogleCalenderUrl")]
        public string GoogleCalenderUrl { get; set; }


        [Required]
        [Display(Name = "ImageUrl")]
        public string ImageUrl { get; set; }

        [Required]
        [Display(Name = "UnpublishDate")]
        public DateTime UnpublishDate { get; set; }
    }
}