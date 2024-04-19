using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Coffee.Application.Common.Exceptions;
using Coffee.Application.Interfaces;
using Coffee.Domain.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Coffee.Application.Users.Queries.GetUserDetails;
public class GetUserDetailsQueryHandler : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
{
    private readonly ICoffeeDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetUserDetailsQueryHandler(ICoffeeDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

    public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Users.FirstOrDefaultAsync(note => note.Id == request.Id, cancellationToken);

        if (entity == null)
        {
            throw new NotFoundException(nameof(User), request.Id);
        }

        return _mapper.Map<UserDetailsVm>(entity);
    }
}
