using System.ComponentModel.DataAnnotations;

namespace HitaRasDhara.Models
{
    public class MobileVerificationViewModel
    {
        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Mobile")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }
    }
}