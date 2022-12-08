using Microsoft.AspNetCore.Authentication.JwtBearer;
using UserModule.Core.Services;

namespace DigiLearn.Web.Infrastructure.JwtUtil;

public class CustomJwtValidation
{
    private readonly IUserFacade _userFacade;

    public CustomJwtValidation(IUserFacade facade)
    {
        _userFacade = facade;
    }

    public async Task Validate(TokenValidatedContext context)
    {
        //var userId = context.Principal.GetUserId();
        //var jwtToken = context.Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
        //var token = await _userFacade.GetUserTokenByJwtToken(jwtToken);
        //if (token == null)
        //{
        //    context.Fail("Token NotFound");
        //    return;
        //}

        //var user = await _userFacade.GetUserById(userId);
        //if (user == null || user.IsActive == false)
        //{
        //    context.Fail("User InActive");
        //    return;
        //}
    }
}