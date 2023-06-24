using CoreModule.Domain.Teacher.Enums;
using CoreModule.Facade.Teacher;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DigiLearn.Web.Infrastructure;

public class TeacherActionFilter : ActionFilterAttribute
{
    private readonly ITeacherFacade _teacherFacade;

    public TeacherActionFilter(ITeacherFacade teacherFacade)
    {
        _teacherFacade = teacherFacade;
    }
    //TODO Should Move Codes To OnResultExecutionAsync
    public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        return base.OnResultExecutionAsync(context, next);
    }

    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (context.HttpContext.User.Identity.IsAuthenticated == false)
            context.Result = new RedirectResult("/");

        var teacher = await _teacherFacade.GetByUserId(context.HttpContext.User.GetUserId());

        if (teacher == null || teacher.Status != TeacherStatus.Active)
            context.Result = new RedirectResult("/Profile");


        await next();
    }
}