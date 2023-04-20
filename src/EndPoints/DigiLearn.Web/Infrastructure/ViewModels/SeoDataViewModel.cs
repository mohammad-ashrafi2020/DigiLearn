using System.ComponentModel.DataAnnotations;
using Common.Domain.ValueObjects;

namespace DigiLearn.Web.Infrastructure.ViewModels;

public class SeoDataViewModel
{
    public string? MetaTitle { get; set; }

    [DataType(DataType.MultilineText)]
    public string? MetaDescription { get; set; }
    public string? MetaKeyWords { get; set; }

    [DataType(DataType.Url)]
    public string? Canonical { get; set; }


    public SeoData Map()
    {
        return new SeoData(MetaKeyWords, MetaDescription, MetaTitle, Canonical);
    }
    public static SeoDataViewModel ConvertToViewModel(SeoData seoData)
    {
        return new SeoDataViewModel()
        {
            Canonical = seoData.Canonical,
            MetaDescription = seoData.MetaDescription,
            MetaKeyWords = seoData.MetaKeyWords,
            MetaTitle = seoData.MetaTitle
        };
    }
}