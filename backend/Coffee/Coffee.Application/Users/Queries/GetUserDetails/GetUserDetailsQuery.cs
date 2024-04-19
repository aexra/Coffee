using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Coffee.Application.Users.Queries.GetUserDetails;
public class GetUserDetailsQuery : IRequest<UserDetailsVm>
{
    public Guid Id { get; set; }
}
