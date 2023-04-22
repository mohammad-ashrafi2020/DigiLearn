using Common.Application;
using CoreModule.Domain.Teacher.Repository;

namespace CoreModule.Application.Teacher.AcceptRequest;

public class AcceptTeacherRequestCommand : IBaseCommand
{
    public Guid TeacherId { get; set; }
}

public class AcceptTeacherRequestCommandHandler : IBaseCommandHandler<AcceptTeacherRequestCommand>
{
    private readonly ITeacherRepository _repository;

    public AcceptTeacherRequestCommandHandler(ITeacherRepository repository)
    {
        _repository = repository;
    }


    public async Task<OperationResult> Handle(AcceptTeacherRequestCommand request, CancellationToken cancellationToken)
    {
        var teacher = await _repository.GetTracking(request.TeacherId);
        if (teacher == null)
            return OperationResult.NotFound();


        teacher.AcceptRequest();
        await _repository.Save();
        return OperationResult.Success();
    }
}