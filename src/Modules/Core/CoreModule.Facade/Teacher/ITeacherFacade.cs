using Common.Application;
using CoreModule.Application.Teacher.AcceptRequest;
using CoreModule.Application.Teacher.Register;
using CoreModule.Application.Teacher.RejectRequest;
using MediatR;

namespace CoreModule.Facade.Teacher;

public interface ITeacherFacade
{
    Task<OperationResult> Register(RegisterTeacherCommand command);
    Task<OperationResult> AcceptRequest(AcceptTeacherRequestCommand command);
    Task<OperationResult> RejectRequest(RejectTeacherRequestCommand command);
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
}