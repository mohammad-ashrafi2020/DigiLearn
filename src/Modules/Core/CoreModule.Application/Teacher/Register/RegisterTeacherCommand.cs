using Common.Application;
using Common.Application.FileUtil.Interfaces;
using CoreModule.Application._Utilities;
using CoreModule.Domain.Teacher.DomainServices;
using CoreModule.Domain.Teacher.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Teacher.Register;

public class RegisterTeacherCommand : IBaseCommand
{
    public IFormFile CvFile { get; set; }
    public string UserName { get; set; }
    public Guid UserId { get; set; }
}

public class RegisterTeacherCommandHandler : IBaseCommandHandler<RegisterTeacherCommand>
{
    private readonly ITeacherRepository _repository;
    private readonly ITeacherDomainService _domainService;
    private readonly ILocalFileService _localFileService;
    public RegisterTeacherCommandHandler(ITeacherRepository repository, ITeacherDomainService domainService, ILocalFileService localFileService)
    {
        _repository = repository;
        _domainService = domainService;
        _localFileService = localFileService;
    }

    public async Task<OperationResult> Handle(RegisterTeacherCommand request, CancellationToken cancellationToken)
    {
        var cvFileName = await _localFileService.SaveFileAndGenerateName(request.CvFile, CoreModuleDirectories.CvFileNames);

        var teacher = new Domain.Teacher.Models.Teacher(cvFileName, request.UserName, request.UserId, _domainService);
        _repository.Add(teacher);
        await _repository.Save();
        return OperationResult.Success();
    }
}


public class RegisterTeacherCommandValidator : AbstractValidator<RegisterTeacherCommand>
{
    public RegisterTeacherCommandValidator()
    {
        RuleFor(r => r.CvFile)
            .NotEmpty()
            .NotNull();

        RuleFor(r => r.UserName)
            .NotEmpty()
            .NotNull();
    }
}
