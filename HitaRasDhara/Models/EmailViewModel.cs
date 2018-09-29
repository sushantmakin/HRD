using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HitaRasDhara.Models
{
    public class EmailViewModel
    {
        public int Id { get; set; }

        public string EmailTo { get; set; }

        public string EmailSubject { get; set; }

        public string EmailBody { get; set; }
    }
}