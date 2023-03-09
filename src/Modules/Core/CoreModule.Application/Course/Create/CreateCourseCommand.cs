using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.ValueObjects;
using CoreModule.Application._Utilities;
using CoreModule.Domain.Course.DomainServices;
using CoreModule.Domain.Course.Enums;
using CoreModule.Domain.Course.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Course.Create;

public class CreateCourseCommand : IBaseCommand
{
    public Guid TeacherId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public IFormFile ImageFile { get; set; }
    public IFormFile? VideoFile { get; set; }
    public int Price { get; set; }
    public SeoData SeoData { get; set; }

    public CourseLevel CourseLevel { get; set; }
    public CourseActionStatus Status { get; set; }

}

class CreateCourseCommandHandler : IBaseCommandHandler<CreateCourseCommand>
{
    private readonly IFtpFileService _ftpFileService;
    private readonly ILocalFileService _localFileService;
    private readonly ICourseRepository _repository;
    private readonly ICourseDomainService _domainService;
    public CreateCourseCommandHandler(IFtpFileService fileService, ILocalFileService localFileService, ICourseDomainService domainService, ICourseRepository repository)
    {
        _ftpFileService = fileService;
        _localFileService = localFileService;
        _domainService = domainService;
        _repository = repository;
    }

    public async Task<OperationResult> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile, CoreModuleDirectories.CourseImage);


        string videoPath = null;
        Guid courseId = Guid.NewGuid();
        if (request.VideoFile != null)
        {
            if (request.VideoFile.IsValidMp4File() == false)
            {
                return OperationResult.Error("فایل وارد شده نامعتبر است");
            }

            //videoPath = await _ftpFileService.SaveFileAndGenerateName(request.VideoFile, CoreModuleDirectories.CourseDemo(courseId));
        }


        var course = new Domain.Course.Models.Course(request.Title, request.TeacherId, request.Description, imageName, videoPath,
            request.Price,
            request.SeoData, request.CourseLevel, request.CategoryId, request.SubCategoryId, request.Slug, request.Status, _domainService)
        {
            Id = courseId
        };

        _repository.Add(course);
        await _repository.Save();
        return OperationResult.Success();
    }
}

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotNull()
            .NotEmpty();

        RuleFor(r => r.Slug)
            .NotNull()
            .NotEmpty();


        RuleFor(r => r.Description)
            .NotNull()
            .NotEmpty();


        RuleFor(r => r.ImageFile)
            .NotNull();
    }
}

