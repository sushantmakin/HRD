
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.UI.WebControls;

namespace HitaRasDhara.Models
{

    public class SadhakSanjeevaniViewModel
    {
        public List<SadhakSanjeevaniItem> SadhakSanjeevaniFeed { get; set; }
    }


    public class SadhakSanjeevaniItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int VideoId { get; set; }

        [Required]
        [Display(Name = "Video Title")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Video Description")]
        public string Description { get; set; }

        [Required]
        [Display(Name = "ThumbnailUrl")]
        public string ThumbnailUrl { get; set; }

        [Required]
        [Display(Name = "YoutubeLink")]
        public string YoutubeLink { get; set; }

        [Required]
        [Display(Name = "VisibleOnHome")]
        public bool VisibleOnHome { get; set; }

        [Required]
        [Display(Name = "VisibleOnInsidePage")]
        public bool VisibleOnInsidePage { get; set; }
    }
}