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
    public override async Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
    {
        if (context.HttpContext.User.Identity.IsAuthenticated == false)
            context.Result = new RedirectResult("/");

        var teacher = await _teacherFacade.GetByUserId(context.HttpContext.User.GetUserId());

        if (teacher == null || teacher.Status != TeacherStatus.Active)
            context.Result = new RedirectResult("/Profile");
        await base.OnResultExecutionAsync(context, next);
    }

    public override void OnResultExecuted(ResultExecutedContext context)
    {
        base.OnResultExecuted(context);
    }

    public override void OnResultExecuting(ResultExecutingContext context)
    {
        base.OnResultExecuting(context);
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        base.OnActionExecuted(context);
    }

    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);
    }


    //public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    //{
    //    if (context.HttpContext.User.Identity.IsAuthenticated == false)
    //        context.Result = new RedirectResult("/");

    //    var teacher = await _teacherFacade.GetByUserId(context.HttpContext.User.GetUserId());

    //    if (teacher == null || teacher.Status != TeacherStatus.Active)
    //        context.Result = new RedirectResult("/Profile");


    //    await next();
    //}
}