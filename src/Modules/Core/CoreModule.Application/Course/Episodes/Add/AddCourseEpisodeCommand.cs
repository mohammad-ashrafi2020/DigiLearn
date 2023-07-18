using Common.Application;
using Common.Application.FileUtil;
using Common.Application.FileUtil.Interfaces;
using Common.Domain.Utils;
using CoreModule.Application._Utilities;
using CoreModule.Domain.Course.Models;
using CoreModule.Domain.Course.Repository;
using Microsoft.AspNetCore.Http;

namespace CoreModule.Application.Course.Episodes.Add;

public class AddCourseEpisodeCommand : IBaseCommand
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public string EnglishTitle { get; set; }
    public Guid SectionId { get; set; }
    public TimeSpan TimeSpan { get; set; }
    public IFormFile VideoFile { get; set; }
    public IFormFile? AttachmentFile { get; set; }
    public bool IsActive { get; set; }
    public bool IsFree { get; set; }
}

public class CreateCourseEpisodeCommandHandler : IBaseCommandHandler<AddCourseEpisodeCommand>
{
    private readonly ICourseRepository _repository;
    private readonly IFtpFileService _ftpFileService;
    private readonly ILocalFileService _localFileService;


    public CreateCourseEpisodeCommandHandler(ICourseRepository repository, IFtpFileService ftpFileService)
    {
        _repository = repository;
        _ftpFileService = ftpFileService;
    }

    public async Task<OperationResult> Handle(AddCourseEpisodeCommand request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetTracking(request.CourseId);
        if (course == null)
        {
            return OperationResult.NotFound();
        }

        string attExName = null;
        if (request.AttachmentFile != null && request.AttachmentFile.IsValidCompressFile())
            attExName = Path.GetExtension(request.AttachmentFile.FileName);

        var episode = course.AddEpisode(request.SectionId, attExName, Path.GetExtension(request.VideoFile.FileName),
            request.TimeSpan, Guid.NewGuid(), request.Title, request.IsActive, request.IsFree, request.EnglishTitle.ToSlug());

        await SaveFiles(request, episode);
        await _repository.Save();
        return OperationResult.Success();
    }

    private async Task SaveFiles(AddCourseEpisodeCommand request, Episode episode)
    {
        await _localFileService.SaveFile(request.VideoFile,
            CoreModuleDirectories.CourseEpisode(request.CourseId, episode.Token), episode.VideoName);

        if (request.AttachmentFile != null)
        {
            if (request.AttachmentFile.IsValidCompressFile())
            {
                await _localFileService.SaveFile(request.VideoFile,
                    CoreModuleDirectories.CourseEpisode(request.CourseId, episode.Token), episode.AttachmentName!);
            }
        }
    }
}