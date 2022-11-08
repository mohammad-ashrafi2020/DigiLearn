namespace Common.Application;

public class SeoDataDto
{
    public string? MetaTitle { get; set; }
    public string? MetaDescription { get; set; }
    public string? MetaKeyWords { get; set; }
    public string? Canonical { get; set; }

    //public SeoData Map()
    //{
    //    return new SeoData(MetaKeyWords, MetaDescription, MetaTitle, Canonical);
    //}
}