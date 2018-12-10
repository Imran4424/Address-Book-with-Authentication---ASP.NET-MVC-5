using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AddressBook.Models
{
    public class Contact
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Display(Name = "Nick Name")]
        public string NickName { get; set; }

        [Required]
        [StringLength(20)]
        public List<string> Mobile { get; set; }

        public string Address { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }
    }
}