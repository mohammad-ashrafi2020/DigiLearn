using Common.Domain;

namespace CoreModule.Domain.Course.Entities;

public class Section : BaseEntity
{
    public Section(int displayOrder, string title, Guid courseId)
    {
        DisplayOrder = displayOrder;
        Title = title;
        CourseId = courseId;
        Episodes = new List<Episode>();
    }

    public Guid CourseId { get; private set; }
    public string Title { get; private set; }
    public int DisplayOrder { get; private set; }

    public IEnumerable<Episode> Episodes { get; private set; }


    public void AddEpisode(string? attachmentName, string videoName, TimeSpan timeSpan, Guid token, string title, bool isActive, string englishTitle)
    {
        Episodes = Episodes.Append(new Episode(attachmentName, videoName, timeSpan, token, title, isActive, Id,englishTitle));
    }
}