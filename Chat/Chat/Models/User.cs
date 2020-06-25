using System;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class User : IdentityUser
    {
        [MaxLength(60)]
        [Required]
        public string FirstName { get; set; }
        
        [MaxLength(60)]
        [Required]
        public string LastName { get; set; }

        public DateTime Birthday { get; set; }
    }
}
