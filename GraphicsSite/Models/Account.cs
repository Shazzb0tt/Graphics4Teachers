using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphicsSite.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public bool hasSubscribed { get; set; }

        [Required]
        public bool isMasterAccount { get; set; }
        [EmailAddress(ErrorMessage = "The emails are either not the same or incorrect format")]

        public string emailOne { get; set; }

        [EmailAddress(ErrorMessage = "The emails are either not the same or incorrect format")]
        public string emailTwo { get; set; }

        public string masterAccountId { get; set; }

        public string ApplicationUserId { get; set; }
    }
}
