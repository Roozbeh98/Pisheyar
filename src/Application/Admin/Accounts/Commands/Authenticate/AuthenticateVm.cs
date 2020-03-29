using System;
using System.Collections.Generic;
using System.Text;

namespace Pisheyar.Application.Accounts.Commands.Authenticate
{
    public class AuthenticateVm
    {
        public string Message { get; set; }

        public int State { get; set; }

        public string Token { get; set; }

        public string Expires { get; set; }
    }
}
