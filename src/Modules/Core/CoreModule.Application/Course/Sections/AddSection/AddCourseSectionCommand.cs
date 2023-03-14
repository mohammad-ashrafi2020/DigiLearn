using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Application;
using CoreModule.Domain.Course.Repository;
using FluentValidation;

namespace CoreModule.Application.Course.Sections.AddSection;

public class AddCourseSectionCommand : IBaseCommand
{
    public Guid CourseId { get; set; }
    public string Title { get; set; }
    public int DisplayOrder { get; set; }
}
class AddCourseSectionCommandHandler : IBaseCommandHandler<AddCourseSectionCommand>
{
    private readonly ICourseRepository _repository;

    public AddCourseSectionCommandHandler(ICourseRepository repository)
    {
        _repository = repository;
    }

    public async Task<OperationResult> Handle(AddCourseSectionCommand request, CancellationToken cancellationToken)
    {
        var course = await _repository.GetTracking(request.CourseId);
        if (course == null)
        {
            return OperationResult.NotFound();
        }

        course.AddSection(request.DisplayOrder, request.Title);
        await _repository.Save();
        return OperationResult.Success();
    }
}

internal class AddCourseSectionCommandValidator : AbstractValidator<AddCourseSectionCommand>
{
    public AddCourseSectionCommandValidator()
    {
        RuleFor(r => r.Title)
            .NotEmpty()
            .NotNull();
    }
}