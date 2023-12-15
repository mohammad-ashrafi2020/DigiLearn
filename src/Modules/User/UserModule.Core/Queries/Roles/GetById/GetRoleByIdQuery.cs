using Common.Query;
using Microsoft.EntityFrameworkCore;
using UserModule.Data;
using UserModule.Data.Entities.Roles;

namespace UserModule.Core.Queries.Roles.GetById;

public record GetRoleByIdQuery(Guid RoleId) : IQuery<Role?>;

class GetRoleByIdQueryHandler : IQueryHandler<GetRoleByIdQuery, Role?>
{
    private readonly UserContext _context;

    public GetRoleByIdQueryHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<Role?> Handle(GetRoleByIdQuery request, CancellationToken cancellationToken)
    {
        return await _context.Roles.Include(c => c.Permissions)
            .FirstOrDefaultAsync(f => f.Id == request.RoleId, cancellationToken);
    }
}