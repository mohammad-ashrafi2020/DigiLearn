using System.Security.Claims;
using System.Security.Principal;

namespace DigiLearn.WebApi.Infrastructure;

public static class ClaimUtils
{
    public static Guid GetUserId(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        var idClaim = principal.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(idClaim, out var userId) ? userId
            : throw new InvalidOperationException("Invalid GUID format.");
    }

    public static string GetUserName(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return Convert.ToString(principal.FindFirst(ClaimTypes.Name)?.Value!);

    }
    public static string GetPhoneNumber(this ClaimsPrincipal principal)
    {
        if (principal == null)
            throw new ArgumentNullException(nameof(principal));

        return principal.FindFirst(ClaimTypes.MobilePhone)?.Value;
    }
    public static string GetEmail(this IIdentity identity)
    {
        ClaimsIdentity claimsIdentity = identity as ClaimsIdentity;
        Claim? claim = claimsIdentity?.FindFirst("Id");
        return claim?.Value ?? string.Empty;
    }

}