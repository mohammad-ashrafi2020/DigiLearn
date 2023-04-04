using System.ComponentModel.DataAnnotations.Schema;
using Common.Domain;
using Common.Domain.ValueObjects;
using CoreModule.Domain.Course.Enums;

namespace CoreModule.Query._Data.Entities;

[Table("Courses", Schema = "course")]
class CourseQueryModel : BaseEntity
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
    public CourseActionStatus Status { get; set; }

    public List<SectionQueryModel> Sections { get; set; }

    [ForeignKey("TeacherId")]
    public TeacherQueryModel Teacher { get; set; }


    [ForeignKey("CategoryId")]
    public CategoryQueryModel Category { get; set; }

    [ForeignKey("SubCategoryId")]
    public CategoryQueryModel SubCategory { get; set; }
}