using MediatR;
using Site.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.UserFeature.Query;

public class LoginUserQuery : IRequest<string>
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
