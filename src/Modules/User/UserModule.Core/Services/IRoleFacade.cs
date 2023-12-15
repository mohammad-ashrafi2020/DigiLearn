using Common.Application;
using MediatR;
using UserModule.Core.Commands.Roles.Create;
using UserModule.Core.Commands.Roles.Delete;
using UserModule.Core.Commands.Roles.Edit;
using UserModule.Core.Queries.Roles.GetAll;
using UserModule.Core.Queries.Roles.GetById;
using UserModule.Data.Entities.Roles;

namespace UserModule.Core.Services;

public interface IRoleFacade
{
    Task<OperationResult> Create(CreateRoleCommand command);
    Task<OperationResult> Edit(EditRoleCommand command);
    Task<OperationResult> Delete(Guid id);


    Task<Role?> GetRoleById(Guid id);
    Task<List<Role>> GetAllRoles();
}

class RoleFacade : IRoleFacade
{
    private readonly IMediator _mediator;

    public RoleFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Create(CreateRoleCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> Edit(EditRoleCommand command)
    {
        return await _mediator.Send(command);

    }

    public async Task<OperationResult> Delete(Guid id)
    {
        return await _mediator.Send(new DeleteRoleCommand(id));

    }

    public async Task<Role?> GetRoleById(Guid id)
    {
        return await _mediator.Send(new GetRoleByIdQuery(id));


    }

    public async Task<List<Role>> GetAllRoles()
    {
        return await _mediator.Send(new GetAllRolesQuery());
    }
}