using Common.Application;
using CoreModule.Application.Teacher.AcceptRequest;
using CoreModule.Domain.Teacher.Repository;

namespace CoreModule.Application.Teacher.RejectRequest;

public class RejectTeacherRequestCommand : IBaseCommand
{
    public Guid TeacherId { get; set; }
    public string Description { get; set; }
}

public class RejectTeacherRequestCommandHandler : IBaseCommandHandler<RejectTeacherRequestCommand>
{
    private readonly ITeacherRepository _repository;

    public RejectTeacherRequestCommandHandler(ITeacherRepository repository)
    {
        _repository = repository;
    }


    public async Task<OperationResult> Handle(RejectTeacherRequestCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetTracking(request.TeacherId);
        if (teacher == null)
            return OperationResult.NotFound();


        _repository.Delete(teacher);
        //Send Event
        await _repository.Save();
        return OperationResult.Success();
    }
}