using Common.Domain.ValueObjects;
using Common.Query;
using CoreModule.Domain.Course.Enums;
using CoreModule.Query._Data.Entities;

namespace CoreModule.Query.Course._DTOs;

public class CourseDto : BaseDto
{
    public Guid TeacherId { get; set; }
    public Guid CategoryId { get; set; }
    public Guid SubCategoryId { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public string? VideoName { get; set; }
    public int Price { get; set; }
    public DateTime LastUpdate { get; set; }
    public SeoData SeoData { get; set; }

    public CourseLevel CourseLevel { get; set; }
    public CourseStatus CourseStatus { get; set; }

    public List<CourseSectionDto> Sections { get; set; }
}

public class CourseSectionDto : BaseDto
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public int DisplayOrder { get; set; }

    public List<EpisodeDto> Episodes { get; set; }
}

public class EpisodeDto : BaseDto
{
    public Guid SectionId { get; set; }
    public string Title { get; set; }
    public string EnglishTitle { get; set; }
    public Guid Token { get; set; }
    public TimeSpan TimeSpan { get; set; }
    public string VideoName { get; set; }
    public string? AttachmentName { get; set; }
    public bool IsActive { get; set; }
}