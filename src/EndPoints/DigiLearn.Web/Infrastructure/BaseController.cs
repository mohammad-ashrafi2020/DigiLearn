using Common.Application;
using Common.Domain.Utils;
using DigiLearn.Web.Infrastructure.RazorUtils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Newtonsoft.Json;

namespace DigiLearn.Web.Infrastructure;

public class BaseController : Controller
{
    protected IActionResult RedirectAndShowAlert(OperationResult result, IActionResult redirectPath, IActionResult errorRedirect)
    {
        var model = JsonConvert.SerializeObject(result);
        HttpContext.Response.Cookies.Append("SystemAlert", model);
        if (result.Status != OperationResultStatus.Success)
            return errorRedirect;

        return redirectPath;
    }
    protected IActionResult RedirectAndShowAlert(OperationResult result, IActionResult redirectPath)
    {
        var model = JsonConvert.SerializeObject(result);
        HttpContext.Response.Cookies.Append("SystemAlert", model);
        if (result.Status != OperationResultStatus.Success)
            return View();

        return redirectPath;
    }
    protected IActionResult RedirectAndShowAlert(OperationResult<Guid> result, IActionResult redirectPath)
    {
        var model = JsonConvert.SerializeObject(result);
        HttpContext.Response.Cookies.Append("SystemAlert", model);
        if (result.Status != OperationResultStatus.Success)
            return View();
        return redirectPath;
    }
    protected void SuccessAlert()
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success());
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    protected void SuccessAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Success(message));
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    protected void ErrorAlert()
    {
        var model = JsonConvert.SerializeObject(OperationResult.Error());
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    protected void ErrorAlert(string message)
    {
        var model = JsonConvert.SerializeObject(OperationResult.Error(message));
        HttpContext.Response.Cookies.Append("SystemAlert", model);
    }
    public async Task<ContentResult> AjaxTryCatch(Func<Task<OperationResult>> func,
        bool isSuccessReloadPage = true,
        string successMessage = "",
        bool isErrorReloadPage = false)
    {
        try
        {
            var res = await func().ConfigureAwait(false);
            var model = new BaseRazor.AjaxResult()
            {
                Status = res.Status,
                Title = res.Title,
                IsReloadPage = isSuccessReloadPage,
                Message = res.Message
            };
            switch (res.Status)
            {
                case OperationResultStatus.Success:
                    {
                        if (string.IsNullOrWhiteSpace(successMessage) == false)
                            model.Message = successMessage;
                        var jsonResult = JsonConvert.SerializeObject(model);
                        return Content(jsonResult);
                    }
                case OperationResultStatus.Error:
                    {
                        model.IsReloadPage = isErrorReloadPage;
                        var jsonResult = JsonConvert.SerializeObject(model);
                        return Content(jsonResult);
                    }
                case OperationResultStatus.NotFound:
                    {
                        model.Title ??= "نتیجه ای یافت نشد";
                        model.IsReloadPage = isErrorReloadPage;
                        var jsonResult = JsonConvert.SerializeObject(model);
                        return Content(jsonResult);
                    }
                default:
                    return Content("Success");

            }
        }
        catch (Exception ex)
        {
            var res = OperationResult.Error(ex.Message);
            var model = new BaseRazor.AjaxResult()
            {
                Status = res.Status,
                Title = res.Title,
                Message = res.Message
            };
            var jsonResult = JsonConvert.SerializeObject(model);
            return Content(jsonResult);
        }
    }
    public async Task<ContentResult> AjaxTryCatch<T>(Func<Task<OperationResult<T>>> func,
        bool isSuccessReloadPage = false,
        bool isErrorReloadPage = false)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                var errors = JoinErrors();
                var modelError = new BaseRazor.AjaxResult()
                {
                    Status = OperationResultStatus.Error,
                    Title = "عملیات ناموفق",
                    Message = errors,
                    IsReloadPage = isErrorReloadPage,
                    Data = default(T)
                };
                var jsonResult = JsonConvert.SerializeObject(modelError);
                return Content(jsonResult);
            }

            var res = await func().ConfigureAwait(false);
            var model = new BaseRazor.AjaxResult()
            {
                Status = res.Status,
                Title = res.Title,
                IsReloadPage = isSuccessReloadPage,
                Message = res.Message,
                Data = res.Data
            };
            switch (res.Status)
            {
                case OperationResultStatus.Success:
                    {
                        var jsonResult = JsonConvert.SerializeObject(model);
                        return Content(jsonResult);
                    }
                case OperationResultStatus.Error:
                    {
                        model.IsReloadPage = isErrorReloadPage;

                        var jsonResult = JsonConvert.SerializeObject(model);
                        return Content(jsonResult);
                    }
                case OperationResultStatus.NotFound:
                    {
                        model.IsReloadPage = isErrorReloadPage;

                        model.Title ??= "Error";
                        var jsonResult = JsonConvert.SerializeObject(model);
                        return Content(jsonResult);
                    }
                default:
                    return Content("Success");

            }
        }
        catch (Exception ex)
        {
            var message = ex.Message.IsUniCode() ? ex.Message : "عملیات ناموفق بود";
            var res = OperationResult.Error(message);
            var model = new BaseRazor.AjaxResult()
            {
                Status = res.Status,
                Title = res.Title,
                IsReloadPage = isErrorReloadPage,
                Message = res.Message
            };
            var jsonResult = JsonConvert.SerializeObject(model);
            return Content(jsonResult);
        }
    }
    protected string JoinErrors()
    {
        var errors = new Dictionary<string, List<string>>();

        if (!ModelState.IsValid)
        {
            if (ModelState.ErrorCount > 0)
            {
                var invalids = ModelState.Values.Where(x => x.ValidationState == ModelValidationState.Invalid).ToArray();

                for (int i = 0; i < ModelState.Values.Count(); i++)
                {
                    var key = ModelState.Keys.ElementAt(i);
                    var value = ModelState.Values.ElementAt(i);

                    if (value.ValidationState == ModelValidationState.Invalid)
                    {
                        errors.Add(key, value.Errors.Select(x => string.IsNullOrEmpty(x.ErrorMessage) ? x.Exception?.Message : x.ErrorMessage).ToList()!);
                    }
                }
            }
        }

        var error = string.Join("<br/>", errors.Select(x =>
        {
            return $"{string.Join(" - ", x.Value)}";

            // return Localizer["msg.join-errors", x.Key, $"({string.Join(") - (", x.Value)})"].Value;
        }));
        return error;
    }
}