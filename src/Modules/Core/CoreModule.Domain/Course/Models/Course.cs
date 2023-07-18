using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using CoreModule.Domain.Course.DomainServices;
using CoreModule.Domain.Course.Enums;
using System.Net.Mail;

namespace CoreModule.Domain.Course.Models;

public class Course : AggregateRoot
{
    private Course()
    {

    }
    public Course(string title, Guid teacherId, string description, string imageName, string? videoName, int price,
        SeoData seoData, CourseLevel courseLevel, Guid categoryId, Guid subCategoryId, string slug, CourseActionStatus status, ICourseDomainService domainService)
    {
        Guard(title, description, imageName, slug);

        if (domainService.SlugIsExist(slug))
            throw new InvalidDomainDataException("Slug is Exist");

        Title = title;
        TeacherId = teacherId;
        Description = description;
        ImageName = imageName;
        VideoName = videoName;
        Price = price;
        LastUpdate = DateTime.Now;
        SeoData = seoData;
        CourseLevel = courseLevel;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Slug = slug;
        CourseStatus = CourseStatus.StartSoon;
        Status = status;

        Sections = new();
    }

    public Guid TeacherId { get; private set; }
    public Guid CategoryId { get; private set; }
    public Guid SubCategoryId { get; private set; }
    public string Title { get; private set; }
    public string Slug { get; private set; }
    public string Description { get; private set; }
    public string ImageName { get; private set; }
    public string? VideoName { get; private set; }
    public int Price { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public SeoData SeoData { get; private set; }

    public CourseLevel CourseLevel { get; private set; }
    public CourseStatus CourseStatus { get; private set; }
    public CourseActionStatus Status { get; set; }

    public List<Section> Sections { get; private set; }



    public void Edit(string title, string description, string imageName, string? videoName, int price,
        SeoData seoData, CourseLevel courseLevel, CourseStatus status, Guid categoryId, Guid subCategoryId, string slug,
    CourseActionStatus actionStatus, ICourseDomainService domainService)
    {
        Guard(title, description, imageName, slug);

        if (Slug != slug)
            if (domainService.SlugIsExist(slug))
                throw new InvalidDomainDataException("Slug is Exist");

        Title = title;
        Description = description;
        ImageName = imageName;
        VideoName = videoName;
        Price = price;
        LastUpdate = DateTime.Now;
        SeoData = seoData;
        CourseLevel = courseLevel;
        CategoryId = categoryId;
        SubCategoryId = subCategoryId;
        Slug = slug;
        CourseStatus = status;
        Status = actionStatus;
    }
    public void AddSection(int displayOrder, string title)
    {
        if (Sections.Any(f => f.Title == title))
            throw new InvalidDomainDataException("title Is Exist");

        Sections.Add(new Section(displayOrder, title, Id));
    }
    public void EditSection(Guid sectionId, int displayOrder, string title)
    {
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null) throw new InvalidDomainDataException("Section NotFound");

        section.Edit(displayOrder, title);
    }
    public void RemoveSection(Guid sectionId)
    {
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null) throw new InvalidDomainDataException("Section NotFound");

        Sections.Remove(section);
    }


    public void EditEpisode(Guid episodeId, Guid sectionId, string title, bool isActive, bool isFree, TimeSpan timeSpan, string? attachmentName)
    {
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null) throw new InvalidDomainDataException("Section NotFound");

        var episode = section.Episodes.FirstOrDefault(f => f.Id == episodeId);
        if (episode == null) throw new InvalidDomainDataException("episode NotFound");

        episode.Edit(title, isActive,isFree, timeSpan, attachmentName);
    }

    public Episode AddEpisode(Guid sectionId, string? attachmentExtension, string videoExtension, TimeSpan timeSpan, Guid token, string title, bool isActive, bool isFree, string englishTitle)
    {

        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null) throw new InvalidDomainDataException("Section NotFound");

        var episodeCount = Sections.Sum(s => s.Episodes.Count());
        var episodeTitle = $"{episodeCount + 1}_{englishTitle}";

        string attName = null;

        if (string.IsNullOrWhiteSpace(attachmentExtension) == false)
            attName = $"{episodeTitle}.{attachmentExtension}";
        var vidName = $"{episodeTitle}.{videoExtension}";

        if (isActive)
        {
            LastUpdate = DateTime.Now;
            if (CourseStatus == CourseStatus.StartSoon)
            {
                CourseStatus = CourseStatus.InProgress;
            }
        }
        return section.AddEpisode(attName, vidName, timeSpan, token, title, isActive, isFree, englishTitle);

    }
    public void AcceptEpisode(Guid episodeId)
    {
        var section = Sections.FirstOrDefault(f => f.Episodes.Any(e => e.Id == episodeId && e.IsActive == false));
        if (section == null)
            throw new InvalidDomainDataException();

        var episode = section.Episodes.First(f => f.Id == episodeId);

        episode.ToggleStatus();
        LastUpdate = DateTime.Now;
    }
    public Episode DeleteEpisode(Guid episodeId)
    {
        var section = Sections.FirstOrDefault(f => f.Episodes.Any(e => e.Id == episodeId));
        if (section == null)
            throw new InvalidDomainDataException();

        var episode = section.Episodes.First(f => f.Id == episodeId);

        section.Episodes.Remove(episode);
        return episode;
    }

    public Episode? GetEpisodeById(Guid sectionId, Guid episodeId)
    {
        var section = Sections.FirstOrDefault(f => f.Episodes.Any(e => e.Id == episodeId));
        if (section == null)
            return null;
        return section.Episodes.FirstOrDefault(f => f.Id == episodeId);
    }
    void Guard(string title, string description, string imageName, string slug)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(slug, nameof(slug));
        NullOrEmptyDomainDataException.CheckString(description, nameof(description));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
}