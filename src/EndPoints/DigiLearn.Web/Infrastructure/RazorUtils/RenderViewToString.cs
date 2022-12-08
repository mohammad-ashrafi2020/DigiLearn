using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace DigiLearn.Web.Infrastructure.RazorUtils;

public interface IRenderViewToString
{
    Task<string> RenderToStringAsync(string viewName, object model, PageContext context);
}

public class RenderViewToString : IRenderViewToString
{
    private readonly IRazorViewEngine _razorViewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;

    public RenderViewToString(IRazorViewEngine razorViewEngine,
        ITempDataProvider tempDataProvider,
        IServiceProvider serviceProvider)
    {
        _razorViewEngine = razorViewEngine;
        _tempDataProvider = tempDataProvider;
        _serviceProvider = serviceProvider;
    }

    public async Task<string> RenderToStringAsync(string viewName, object model, PageContext context)
    {
        var httpContext = new DefaultHttpContext { RequestServices = _serviceProvider };

        using (var sw = new StringWriter())
        {
            var viewResult = _razorViewEngine.FindView(context, viewName, false);

            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{viewName} does not match any available view");
            }

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            var viewContext = new ViewContext(
                context,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(context.HttpContext, _tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }
    }
}