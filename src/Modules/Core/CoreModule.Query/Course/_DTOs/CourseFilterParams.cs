using Common.Query;
using Common.Query.Filter;
using CoreModule.Domain.Course.Enums;

namespace CoreModule.Query.Course._DTOs;

public class CourseFilterParams : BaseFilterParam
{
    public Guid? TeacherId { get; set; }
    public CourseActionStatus? ActionStatus { get; set; } = null;
    public CourseStatus? CourseStatus { get; set; } = null;
    public CourseLevel? CourseLevel { get; set; } = null;
    public CourseFilterSort FilterSort { get; set; } = CourseFilterSort.Latest;
    public SearchByPrice SearchByPrice { get; set; } = SearchByPrice.All;
    public string CategorySlug { get; set; }
    public string Search { get; set; }
}

public enum SearchByPrice
{
    All,
    Free,
    NotFree
}
public enum CourseFilterSort
{
    Latest,
    Oldest,
    Expensive,
}
public class CourseFilterResult : BaseFilter<CourseFilterData>
{

}
public class CourseFilterData : BaseDto
{
    public string ImageName { get; set; }
    public string Title { get; set; }
    public string Slug { get; set; }
    public int Price { get; set; }
    public CourseActionStatus CourseStatus { get; set; }
    public int EpisodeCount => Sections.Sum(s => s.Episodes.Count);
    public string Teacher { get; set; }
    public List<CourseSectionDto> Sections { get; set; }

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
}