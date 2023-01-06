using Common.Domain;

namespace CoreModule.Domain.Course.Entities;

public class Episode : BaseEntity
{
    public Episode(string attachmentName, string videoName, TimeSpan timeSpan, Guid token, string title, bool isActive)
    {
        IsActive = isActive;
        AttachmentName = attachmentName;
        VideoName = videoName;
        TimeSpan = timeSpan;
        Token = token;
        Title = title;
    }

    public string Title { get; private set; }
    public Guid Token { get; private set; }
    public TimeSpan TimeSpan { get; private set; }
    public string VideoName { get; private set; }
    public string AttachmentName { get; private set; }
    public bool IsActive { get; private set; }
}