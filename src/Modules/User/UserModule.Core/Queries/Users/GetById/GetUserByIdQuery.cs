using AutoMapper;
using Common.Query;
using Microsoft.EntityFrameworkCore;
using UserModule.Core.Queries._DTOs;
using UserModule.Data;

namespace UserModule.Core.Queries.Users.GetById;

public record GetUserByIdQuery(Guid Id) : IQuery<UserDto?>;

class GetUserByIdQueryHandler : IQueryHandler<GetUserByIdQuery, UserDto?>
{
    private readonly UserContext _context;
    private readonly IMapper _mapper;

    public GetUserByIdQueryHandler(UserContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<UserDto?> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await _context.Users.FirstOrDefaultAsync(f => f.Id == request.Id, cancellationToken);
        if (user == null)
        {
            return null;
        }

        return _mapper.Map<UserDto>(user);
    }
}