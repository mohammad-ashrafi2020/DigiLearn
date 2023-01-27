namespace CoreModule.Domain.Teacher.DomainServices;

public interface ITeacherDomainService
{
    bool UserNameIsExist(string userName);
}