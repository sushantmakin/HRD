using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitaRasDhara.Models
{
    public class UserResponse5Aug
    {
        [Required]
        [Display(Name = "Full Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MMM/yyyy}")]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Key]
        [Display(Name = "Phone")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Entered phone format is not valid.")]
        public string Phone { get; set; }

        
        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Seat Status")]
        [Required]
        public string SeatStatus { get; set; }


        [Display(Name = "Question from the master (if any)")]
        public string Question { get; set; }


    }
}