using CoreModule.Domain.Teacher.DomainServices;
using CoreModule.Domain.Teacher.Repository;

namespace CoreModule.Application.Teacher;

public class TeacherDomainService : ITeacherDomainService
{
    private readonly ITeacherRepository _repository;

    public TeacherDomainService(ITeacherRepository repository)
    {
        _repository = repository;
    }

    public bool UserNameIsExist(string userName)
    {
        return _repository.Exists(f => f.UserName == userName.ToLower());
    }
}