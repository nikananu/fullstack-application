using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Account.Application.Dtos
{
    public class LoginRequestDto
    {
       

        [Required]
        [EmailAddress]
        public string Email { get; set; }= string.Empty;

        [Required]
        [MinLength(8,ErrorMessage ="Password must be at least 8 characters.")]
        public string Password { get; set; }= string.Empty;

    }

}
