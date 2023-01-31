using FluentValidation;

namespace CoreModule.Application.Category.Edit;

public class EditCategoryCommandValidator : AbstractValidator<EditCategoryCommand>
{
    public EditCategoryCommandValidator()
    {
        RuleFor(f => f.Title)
            .NotEmpty()
            .NotNull();


        RuleFor(f => f.Slug)
            .NotEmpty()
            .NotNull();
    }
}