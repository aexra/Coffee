using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Coffee.Application.Users.Commands.DeleteUser;
public class DeleteUserCommand : IRequest
{
    public Guid Id { get; set; }
}
