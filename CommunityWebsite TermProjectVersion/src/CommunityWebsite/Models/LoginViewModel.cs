using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CommunityWebsite.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        [StringLength(20, MinimumLength = 5)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password cannot be empty")]
        [RegularExpression(@"^((?=\S*?[A-Z])(?=\S*?[a-z])(?=\S*?[0-9]).{6,})\S$", ErrorMessage = "Password must have 6 characters, 1 Upper, 1 Lower, and 1 number")]
        public string Password { get; set; }
    }
}
