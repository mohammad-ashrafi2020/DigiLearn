using Common.Domain;
using Common.Domain.Exceptions;
using Common.Domain.Utils;
using CoreModule.Domain.Teacher.DomainServices;
using CoreModule.Domain.Teacher.Enums;
using CoreModule.Domain.Teacher.Events;

namespace CoreModule.Domain.Teacher.Models;

public class Teacher : AggregateRoot
{
    private Teacher()
    {

    }
    public Teacher(string cvFileName, string userName, Guid userId, ITeacherDomainService domainService)
    {
        NullOrEmptyDomainDataException.CheckString(cvFileName, nameof(cvFileName));
        NullOrEmptyDomainDataException.CheckString(userName, nameof(userName));

        if (userName.IsUniCode())
            throw new InvalidDomainDataException("UserName Invalid");

        if (domainService.UserNameIsExist(userName))
            throw new InvalidDomainDataException("UserName Is Exist");

        CvFileName = cvFileName;
        UserName = userName.ToLower();
        UserId = userId;
        Status = TeacherStatus.Pending;
    }

    public Guid UserId { get; private set; }
    public string UserName { get; private set; }
    public string CvFileName { get; private set; }
    public TeacherStatus Status { get; private set; }


    public void ToggleStatus()
    {
        if (Status == TeacherStatus.Active)
        {
            Status = TeacherStatus.Inactive;
        }
        else if (Status == TeacherStatus.Inactive)
        {
            Status = TeacherStatus.Active;
        }
    }
    public void AcceptRequest()
    {
        if (Status == TeacherStatus.Pending)
        {
            //Event
            AddDomainEvent(new AcceptTeacherRequestEvent()
            {
                UserId = UserId
            });
            Status = TeacherStatus.Active;
        }
    }
}