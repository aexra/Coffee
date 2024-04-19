using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coffee.Application.Interfaces;
using Coffee.Domain.Models;
using MediatR;

namespace Coffee.Application.Users.Commands.CreateUser;
public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
{
    private readonly ICoffeeDbContext _dbContext;

    public CreateUserCommandHandler(ICoffeeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var user = new User
        {
            Id = Guid.NewGuid(),
            FIO = request.FIO,
            Coffee = request.Coffee,
            BirthDate = request.BirthDate,
            HiredSince = request.HiredSince,
            JobTitle = request.JobTitle,
            Hobbies = request.Hobbies,
            Interests = request.Interests,
            PhoneNumber = request.PhoneNumber,
            TGID = request.TGID,
            Pets = request.Pets,
        };

        await _dbContext.Users.AddAsync(user);

        return user.Id;
    }
}
