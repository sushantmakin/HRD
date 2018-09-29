using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HitaRasDhara.Models
{
    public class QueryViewModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Display(Name = "QueryId")]
        public string QueryId { get; set; }

        [Required]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "PhoneCountryCode")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneCountryCode { get; set; }

        [Required]
        [Display(Name = "Mobile")]
        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Entered phone format is not valid.")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "City")]
        public string City { get; set; }

        [Required]
        [Display(Name = "State")]
        public string State { get; set; }

        [Required]
        [Display(Name = "Country")]
        public string Country { get; set; }

        [Required]
        [Display(Name = "Query")]
        public string Query { get; set; }

        [Required]
        [Display(Name = "TimeStamp")]
        public DateTime TimeStamp { get; set; }

        [Required]
        [Display(Name= "Status")]
        public string Status { get; set; }

        [Required]
        [Display(Name = "Response")]
        public string Response { get; set; }
    }
}