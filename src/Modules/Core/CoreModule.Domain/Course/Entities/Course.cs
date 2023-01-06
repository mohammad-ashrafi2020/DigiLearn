using Common.Domain;
using Common.Domain.ValueObjects;
using CoreModule.Domain.Course.Enums;

namespace CoreModule.Domain.Course.Entities;

public class Course : BaseEntity
{
    public Guid TeacherId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageName { get; set; }
    public string VideoName { get; set; }
    public int Price { get; set; }
    public DateTime LastUpdate { get; set; }
    public SeoData SeoData { get; set; }

    public CourseLevel CourseLevel { get; set; }
    public CourseStatus CourseStatus { get; set; }


    public List<Section> Sections { get; set; }

}