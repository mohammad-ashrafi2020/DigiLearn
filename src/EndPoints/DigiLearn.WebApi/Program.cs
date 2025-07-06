using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using BlogModule;
using CommentModule;
using CoreModule.Config;
using TicketModule;
using TransactionModule;
using UserModule.Core;
using Microsoft.OpenApi.Models;
using DigiLearn.WebApi.Infrastructure;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using DigiLearn.WebApi.Infrastructure.Middlewares;
using DigiLearn.WebApi.Infrastructure.JwtUtils;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
.ConfigureApiBehaviorOptions(option =>
{
    option.InvalidModelStateResponseFactory = (context) =>
    {
        // کدهای قبلی شما
        var result = new ApiResult()
        {
            IsSuccess = false,
            MetaData = new()
            {
                AppStatusCode = AppStatusCode.BadRequest,
                Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
            }
        };
        return new BadRequestObjectResult(result);
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter Token",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = JwtBearerDefaults.AuthenticationScheme
                }
            },
            Array.Empty<string>()
        }
    });
    //option.AddSecurityRequirement(new OpenApiSecurityRequirement
    //{
    //    { jwtSecurityScheme, Array.Empty<string>() }
    //});
//    option.AddSecurityRequirement(new OpenApiSecurityRequirement
//{
//    {
//        jwtSecurityScheme,
//        new[] { JwtBearerDefaults.AuthenticationScheme } // ????? ???? ????? ?????
//    }

//});
});


builder.Services.AddTransient<ILocalFileService, LocalFileService>();
builder.Services.AddTransient<IFtpFileService, FtpFileService>();


builder.Services
    .InitUserModule(builder.Configuration)
    .InitTicketModule(builder.Configuration)
    .InitCoreModule(builder.Configuration)
    .InitBlogModule(builder.Configuration)
    .InitCommentModule(builder.Configuration)
    .InitTransactionModule(builder.Configuration)
    .RegisterWebDependencies();


#region JWT

builder.Services.AddJwtAuthentication(builder.Configuration);

#endregion
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});
var app = builder.Build();

// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}


app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.UseCors("AllowAll");

app.UseApiCustomExceptionHandler();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    });
}

app.Run();
