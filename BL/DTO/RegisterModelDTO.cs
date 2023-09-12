using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class RegisterModelDTO
    {
        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;

        public string RepeatPassowrd { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
    }
}
