using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee.Application.Common.Exceptions;
using Coffee.Application.Interfaces;
using Coffee.Domain.Models;
using MediatR;

namespace Coffee.Application.Users.Commands.DeleteUser;
public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly ICoffeeDbContext _dbContext;

    public DeleteUserCommandHandler(ICoffeeDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users.FindAsync(new object[] { request.Id }, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        _dbContext.Users.Remove(entity);

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
