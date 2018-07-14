using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HitaRasDhara.Models
{
    public class SMSContent
    {
        [Required]
        [Key]
        public string Key { get; set; }

        public string Value { get; set; }
    }
}