using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.ValueObjects;
using CoreModule.Domain.Course.Enums;

namespace CoreModule.Domain.Course.Entities;

public class Course : BaseEntity
{
    public Course(string title, Guid teacherId, string description, string imageName, string? videoName, int price, SeoData seoData, CourseLevel courseLevel)
    {
        Guard(title, description, imageName);
        Title = title;
        TeacherId = teacherId;
        Description = description;
        ImageName = imageName;
        VideoName = videoName;
        Price = price;
        LastUpdate = DateTime.Now;
        SeoData = seoData;
        CourseLevel = courseLevel;
        CourseStatus = CourseStatus.StartSoon;

        Sections = new();
    }

    public Guid TeacherId { get; private set; }
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string ImageName { get; private set; }
    public string? VideoName { get; private set; }
    public int Price { get; private set; }
    public DateTime LastUpdate { get; private set; }
    public SeoData SeoData { get; private set; }

    public CourseLevel CourseLevel { get; private set; }
    public CourseStatus CourseStatus { get; private set; }

    public List<Section> Sections { get; private set; }

    public void AddSection(int displayOrder, string title)
    {
        if (Sections.Any(f => f.Title == title))
            throw new InvalidDomainDataException("title Is Exist");

        Sections.Add(new Section(displayOrder, title, Id));
    }
    public void RemoveSection(Guid sectionId)
    {
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null) throw new InvalidDomainDataException("Section NotFound");

        Sections.Remove(section);
    }
    public void AddEpisode(Guid sectionId, string? attachmentExtension, string videoExtension, TimeSpan timeSpan, Guid token, string title, bool isActive, string englishTitle)
    {
        var section = Sections.FirstOrDefault(f => f.Id == sectionId);
        if (section == null) throw new InvalidDomainDataException("Section NotFound");

        var episodeCount = Sections.Sum(s => s.Episodes.Count());
        var episodeTitle = $"{episodeCount + 1}_{englishTitle}";

        string attName = null;

        if (string.IsNullOrWhiteSpace(attachmentExtension) == false)
            attName = $"{episodeTitle}.{attachmentExtension}";
        var vidName = $"{episodeTitle}.${videoExtension}";

        section.AddEpisode(attName, vidName, timeSpan, token, title, isActive, englishTitle);
    }
    void Guard(string title, string description, string imageName)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        NullOrEmptyDomainDataException.CheckString(description, nameof(description));
        NullOrEmptyDomainDataException.CheckString(imageName, nameof(imageName));
    }
}