using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models.AuthorizationViewModels
{
    public class LoginViewModel
    {
        [Required]
        [UIHint("Email")]
        public string Email { get; set; }
        [Required]
        [UIHint("Password")]
        public string Password { get; set; }

        public bool RememberMe { get; set; } 
    }
}
