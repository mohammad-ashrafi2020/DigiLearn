using AngleSharp.Html.LinkRels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using UserModule.Core.Services;
using UserModule.Data.Entities._Enums;
using UserModule.Data.Entities.Roles;

namespace DigiLearn.WebApi.Infrastructure.Security;

public class PermissionChecker : AuthorizeAttribute, IAsyncAuthorizationFilter
{
    private IUserFacade _userFacade = null!;
    private IRoleFacade _roleFacade = null!;
    private readonly Permissions _permission;

    public PermissionChecker(Permissions permission)
    {
        _permission = permission;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {

        _userFacade = context.HttpContext.RequestServices.GetRequiredService<IUserFacade>();
        _roleFacade = context.HttpContext.RequestServices.GetRequiredService<IRoleFacade>();
        if (context.HttpContext.User.Identity != null && context.HttpContext.User.Identity.IsAuthenticated)
        {
            if (await UserHasPermission(context) == false)
            {
                context.Result = new ForbidResult();
            }
        }
        else
        {
            context.Result = new UnauthorizedObjectResult("Unauthorize");
        }
    }

    private bool HasAllowAnonymous(AuthorizationFilterContext context)
    {
        if (_roleFacade == null && _userFacade == null)
        {
            return false;
            throw new Exception("مشکل سمت سرور به وجود آمده");
        }
        var metaData = context.ActionDescriptor.EndpointMetadata.OfType<dynamic>().ToList();
        bool hasAllowAnonymous = false;
        foreach (var f in metaData)
        {
            try
            {
                hasAllowAnonymous = f.TypeId.Name == "AllowAnonymousAttribute";
                if (hasAllowAnonymous)
                    break;
            }
            catch
            {
                // ignored
            }
        }

        return hasAllowAnonymous;
    }
    private async Task<bool> UserHasPermission(AuthorizationFilterContext context)
    {
        var user = await _userFacade.GetUserByPhoneNumber(context.HttpContext.User.GetPhoneNumber());
        if (user == null)
            return false;

        var roleNames = user.Roles.Select(s => s.Title).ToList();
        var roles = await _roleFacade.GetAllRoles();
        if (roles == null)
        {
            return false;
        }
        var userRoles = roles.Where(i => roleNames.Contains(i.Name)).ToList();

        return userRoles.Any(i => i.Permissions.Any(s=>s.Permissions.Equals(_permission)));
    }
}