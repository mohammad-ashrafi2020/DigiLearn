using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Application.SecurityUtil;
using Common.Domain.ValueObjects;
using CoreModule.Application._Utilities;
using CoreModule.Application.Course.Create;
using CoreModule.Domain.Course.DomainServices;
using CoreModule.Domain.Course.Enums;
using CoreModule.Domain.Course.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Course.Edit;

public class EditCourseCommand : IBaseCommand
{
    public Guid CourseId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public IFormFile? ImageFile { get; set; }
    public IFormFile? VideoFile { get; set; }
    public int Price { get; set; }
    public SeoData SeoData { get; set; }

    public CourseLevel CourseLevel { get; set; }
    public CourseStatus CourseStatus { get; set; }
    public CourseActionStatus CourseActionStatus { get; set; }
}



class EditCourseCommandHandler : IBaseCommandHandler<EditCourseCommand>
{
    private readonly ILocalFileService _localFileService;
    private readonly ICourseRepository _repository;
    private readonly ICourseDomainService _domainService;
    public EditCourseCommandHandler(ILocalFileService localFileService, ICourseDomainService domainService, ICourseRepository repository)
    {
        _localFileService = localFileService;
        _domainService = domainService;
        _repository = repository;
    }

    public async Task<OperationResult> Handle(EditCourseCommand request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetTracking(request.CourseId);
        if (course == null)
        {
            return OperationResult.NotFound();
        }
        var imageName = course.ImageName;
        string videoPath = course.VideoName;

        var oldVideoFileName = course.VideoName;
        var oldImageNameFileName = course.ImageName;
        if (request.VideoFile != null)
        {
            if (request.VideoFile.IsValidMp4File() == false)
            {
                return OperationResult.Error("فایل وارد شده نامعتبر است");
            }

            videoPath = await _localFileService.SaveFileAndGenerateName(request.VideoFile, CoreModuleDirectories.CourseDemo(course.Id));
        }

        if (request.ImageFile.IsImage())
        {
            imageName = await _localFileService.SaveFileAndGenerateName(request.ImageFile!, CoreModuleDirectories.CourseImage);
        }


        course.Edit(request.Title, request.Description, imageName, videoPath,
            request.Price,
            request.SeoData, request.CourseLevel, request.CourseStatus, request.CategoryId, request.SubCategoryId, request.Slug, request.CourseActionStatus,
            _domainService);
        await _repository.Save();

        DeleteOldFiles(oldImageNameFileName, oldVideoFileName,
           request.VideoFile != null,
           request.ImageFile != null, course);
        return OperationResult.Success();

    }


    void DeleteOldFiles(string image, string? video, bool isUploadNewVideo, bool isUploadNewImage, Domain.Course.Models.Course course)
    {
        if (isUploadNewVideo && string.IsNullOrWhiteSpace(video) == false)
        {
            _localFileService.DeleteFile(CoreModuleDirectories.CourseDemo(course.Id), video);
        }

        if (isUploadNewImage)
        {
            _localFileService.DeleteFile(CoreModuleDirectories.CourseImage, image);
        }
    }
}

public class EditCourseCommandValidator : AbstractValidator<EditCourseCommand>
{
    public EditCourseCommandValidator()
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

