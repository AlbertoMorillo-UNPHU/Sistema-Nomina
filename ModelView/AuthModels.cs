using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SistemaNomina.ModelView
{
    public class AuthModels
    {
       
        public class RegisterFeedback
        {
            public string Username { get; set; }
            public string Errors { get; set; }
            public bool Success { get; set; }
        }

        public class LoginFeedback
        {
            public bool Success { get; set; }
            public string Errors { get; set; }
            public Guid AuthKey { get; set; }
            public long UserId { get; set; }
        }

        public class Login
        {
            public string Username { get; set; }
            public string Password { get; set; }
        }

        public class Register
        {
            public string Username { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string Password { get; set; }
            public string ConfirmPassword { get; set; }
        }
    }
}
