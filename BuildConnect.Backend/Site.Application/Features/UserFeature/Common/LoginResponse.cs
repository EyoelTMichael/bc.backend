using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.UserFeature.Common
{
    public class LoginResponse
    {
        public string Token { get; set; }
        public UserDTO User { get; set; }

    }
}
