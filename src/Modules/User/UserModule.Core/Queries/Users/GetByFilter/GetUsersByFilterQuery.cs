using Common.Query;
using Microsoft.EntityFrameworkCore;
using UserModule.Core.Queries._DTOs;
using UserModule.Data;

namespace UserModule.Core.Queries.Users.GetByFilter;

public class GetUsersByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUsersByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}
public class GetUsersByFilterQueryHandler : IQueryHandler<GetUsersByFilterQuery, UserFilterResult>
{
    private readonly UserContext _context;

    public GetUsersByFilterQueryHandler(UserContext context)
    {
        _context = context;
    }

    public async Task<UserFilterResult> Handle(GetUsersByFilterQuery request, CancellationToken cancellationToken)
    {
        var result = _context.Users.OrderByDescending(d => d.CreationDate)
            .AsQueryable();

        if (string.IsNullOrWhiteSpace(request.FilterParams.Email) == false)
        {
            result = result.Where(r => r.Email.Contains(request.FilterParams.Email));
        }

        if (string.IsNullOrWhiteSpace(request.FilterParams.PhoneNumber) == false)
        {
            result = result.Where(r => r.PhoneNumber.Contains(request.FilterParams.PhoneNumber));
        }

        if (request.FilterParams.StartDate != null)
        {
            result = result.Where(r => r.CreationDate.Date >= request.FilterParams.StartDate.Value.Date);
        }

        if (request.FilterParams.EndDate != null)
        {
            result = result.Where(r => r.CreationDate.Date <= request.FilterParams.EndDate.Value.Date);
        }

        var skip = (request.FilterParams.PageId - 1) * request.FilterParams.Take;
        var model = new UserFilterResult()
        {
            Data = await result.Skip(skip).Take(request.FilterParams.Take).Select(s => new UserDto
            {
                Id = s.Id,
                CreationDate = s.CreationDate,
                Name = s.Name,
                Family = s.Family,
                PhoneNumber = s.PhoneNumber,
                Email = s.Email,
                Password = null,
                Avatar = s.Avatar,
                Roles = null
            }).ToListAsync(cancellationToken)
        };
        model.GeneratePaging(result, request.FilterParams.Take, request.FilterParams.PageId);
        return model;
    }
}