using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphics4Teachers.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        public bool hasSubscribed { get; set; }

        [Required]
        public bool isMasterAccount { get; set; }

        public string emailOne { get; set; }

        public string emailTwo { get; set; }

        public string masterAccountId { get; set; }
    [Required]
        public string ApplicationUserId { get; set; }
    }
}
