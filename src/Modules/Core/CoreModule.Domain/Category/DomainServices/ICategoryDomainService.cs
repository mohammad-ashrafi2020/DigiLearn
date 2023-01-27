namespace CoreModule.Domain.Category.DomainServices;

public interface ICategoryDomainService
{
    bool SlugIsExist(string slug);
}