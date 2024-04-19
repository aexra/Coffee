using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee.Application.Common.Exceptions;
using Coffee.Application.Interfaces;
using Coffee.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Application.Users.Commands.UpdateUser;
public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
{
    private readonly ICoffeeDbContext _dbContext;

    public UpdateUserCommandHandler(ICoffeeDbContext dbContext) => _dbContext = dbContext;

    public async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users.FirstOrDefaultAsync(user => user.Id == request.Id, cancellationToken);

        if (entity == null) 
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        entity.FIO = request.FIO;
        entity.Coffee = request.Coffee;
        entity.BirthDate = request.BirthDate;
        entity.HiredSince = request.HiredSince;
        entity.JobTitle = request.JobTitle;
        entity.Hobbies = request.Hobbies;
        entity.Interests = request.Interests;
        entity.PhoneNumber = request.PhoneNumber;
        entity.TGID = request.TGID;
        entity.Pets = request.Pets;

        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
