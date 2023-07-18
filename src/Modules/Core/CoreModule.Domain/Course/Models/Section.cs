using Common.Domain;
using Common.Domain.Exceptions;

namespace CoreModule.Domain.Course.Models;

public class Section : BaseEntity
{
    public Section(int displayOrder, string title, Guid courseId)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        DisplayOrder = displayOrder;
        Title = title;
        CourseId = courseId;
        Episodes = new List<Episode>();
    }

    public Guid CourseId { get; private set; }
    public string Title { get; private set; }
    public int DisplayOrder { get; private set; }

    public List<Episode> Episodes { get; private set; }


    public void Edit(int displayOrder, string title)
    {
        NullOrEmptyDomainDataException.CheckString(title, nameof(title));
        DisplayOrder = displayOrder;
        Title = title;
    }
    public Episode AddEpisode(string? attachmentName, string videoName, TimeSpan timeSpan, Guid token, string title, bool isActive, bool isFree, string englishTitle)
    {
        var episode = new Episode(attachmentName, videoName, timeSpan, token, title, isActive,isFree, Id, englishTitle);
        Episodes.Add(episode);
        return episode;
    }


}