namespace CoreModule.Domain.Course.DomainServices;

public interface ICourseDomainService
{
    bool SlugIsExist(string slug);
}