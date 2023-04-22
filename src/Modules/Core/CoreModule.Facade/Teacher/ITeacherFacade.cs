using Common.Application;
using CoreModule.Application.Teacher.AcceptRequest;
using CoreModule.Application.Teacher.Register;
using CoreModule.Application.Teacher.RejectRequest;
using CoreModule.Application.Teacher.ToggleStatus;
using CoreModule.Query.Teacher._DTOs;
using CoreModule.Query.Teacher.GetById;
using CoreModule.Query.Teacher.GetByUserId;
using CoreModule.Query.Teacher.GetList;
using MediatR;

namespace CoreModule.Facade.Teacher;

public interface ITeacherFacade
{
    Task<OperationResult> Register(RegisterTeacherCommand command);
    Task<OperationResult> AcceptRequest(AcceptTeacherRequestCommand command);
    Task<OperationResult> RejectRequest(RejectTeacherRequestCommand command);
    Task<OperationResult> ToggleStatus(Guid teacherId);



    Task<TeacherDto?> GetById(Guid id);
    Task<TeacherDto?> GetByUserId(Guid userId);
    Task<List<TeacherDto>> GetList();
}
class TeacherFacade : ITeacherFacade
{
    private readonly IMediator _mediator;

    public TeacherFacade(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task<OperationResult> Register(RegisterTeacherCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> AcceptRequest(AcceptTeacherRequestCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> RejectRequest(RejectTeacherRequestCommand command)
    {
        return await _mediator.Send(command);
    }

    public async Task<OperationResult> ToggleStatus(Guid teacherId)
    {
        return await _mediator.Send(new ToggleTeacherStatusCommand(teacherId));

    }

    public async Task<TeacherDto?> GetById(Guid id)
    {
        return await _mediator.Send(new GetTeacherByIdQuery(id));
    }

    public async Task<TeacherDto?> GetByUserId(Guid userId)
    {
        return await _mediator.Send(new GetTeacherByUserIdQuery(userId));

    }

    public async Task<List<TeacherDto>> GetList()
    {
        return await _mediator.Send(new GetTeacherListQuery());
    }
}