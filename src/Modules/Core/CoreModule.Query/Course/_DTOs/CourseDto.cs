using Common.Domain.ValueObjects;
using Common.Query;
using CoreModule.Domain.Course.Enums;
using CoreModule.Query._Data.Entities;
using CoreModule.Query.Category._DTOs;
using CoreModule.Query.Teacher._DTOs;

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
    public TeacherDto Teacher { get; set; }
    public CourseLevel CourseLevel { get; set; }
    public CourseStatus CourseStatus { get; set; }
    public CourseActionStatus Status { get; set; }
    public List<CourseSectionDto> Sections { get; set; }
    public CourseCategoryDto MainCategory { get; set; }
    public CourseCategoryDto SubCategory { get; set; }

    public string GetDuration()
    {
        int totalSeconds = 0;
        int totalMinutes = 0;
        int totalHours = 0;
        foreach (var section in Sections)
        {
            foreach (var item in section.Episodes)
            {
                totalSeconds += item.TimeSpan.Seconds;
                totalMinutes += item.TimeSpan.Minutes;
                totalHours += item.TimeSpan.Hours;
            }

            while (totalSeconds > 60)
            {
                totalMinutes += 1;
                totalSeconds -= 60;
            }
            while (totalMinutes >= 60)
            {
                totalHours += 1;
                totalMinutes -= 60;
            }
        }
        return $"{totalHours:00} : {totalMinutes:00} : {totalSeconds:00}";
    }
    public string GetCourseStatus()
    {
        switch (CourseStatus)
        {
            case CourseStatus.StartSoon:
                return "شروع به زودی";
            case CourseStatus.Completed:
                return "به اتمام رسیده";
            case CourseStatus.InProgress:
                return "درحال برگزاری";
            default:
                return "";
        }

        return "";
    }
    public string GetCourseLevel()
    {
        switch (CourseLevel)
        {
            case CourseLevel.Beginner:
                return "مقدماتی";
            case CourseLevel.Expert:
                return "پیشرفته";
            case CourseLevel.Intermediate:
                return "از مقدماتی تا پیشرفته";
            default:
                return "";
        }

        return "";
    }
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
    public bool IsFree { get; set; }
}