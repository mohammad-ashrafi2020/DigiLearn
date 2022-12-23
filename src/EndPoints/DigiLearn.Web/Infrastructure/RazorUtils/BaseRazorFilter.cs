using Common.Query.Filter;
using Microsoft.AspNetCore.Mvc;

namespace DigiLearn.Web.Infrastructure.RazorUtils
{
    public class BaseRazorFilter<TFilterParam> : BaseRazor where TFilterParam : BaseFilterParam, new()
    {
        public BaseRazorFilter()
        {
            FilterParams = new TFilterParam();
        }
        [BindProperty(SupportsGet = true)]
        public TFilterParam FilterParams { get; set; }
    }
}