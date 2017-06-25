using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace tanchi.DTOs
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "UserName is required.", AllowEmptyStrings = false)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required.", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
