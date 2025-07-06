using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DigiLearn.WebApi.Infrastructure;

public class ModelStateUtil
{
    public static string GetModelStateErrors(ModelStateDictionary modelState)
    {
        var errors = new Dictionary<string, List<string>>();

        if (!modelState.IsValid)
        {
            if (modelState.ErrorCount > 0)
            {
                for (int i = 0; i < modelState.Values.Count(); i++)
                {
                    var key = modelState.Keys.ElementAt(i);
                    var value = modelState.Values.ElementAt(i);

                    if (value.ValidationState == ModelValidationState.Invalid)
                    {
                        errors.Add(key, value.Errors.Select(x => string.IsNullOrEmpty(x.ErrorMessage) ? x.Exception?.Message : x.ErrorMessage).ToList());
                    }
                }
            }
        }
        var error = string.Join(" - ", errors.Select(x => $"{string.Join(" - ", x.Value)}"));
        return error;
    }
}