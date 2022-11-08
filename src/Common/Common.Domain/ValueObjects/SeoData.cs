using System.Collections.Generic;

namespace Common.Domain.ValueObjects
{
    public class SeoData : ValueObject
    {
        private SeoData()
        {
        }

        public static SeoData CreateEmpty()
        {
            return new SeoData();
        }

        public SeoData(string? metaKeyWords, string? metaDescription, string? metaTitle, string? canonical)
        {
            MetaKeyWords = metaKeyWords;
            MetaDescription = metaDescription;
            MetaTitle = metaTitle;
            Canonical = canonical;
        }

        public string? MetaTitle { get; private set; }
        public string? MetaDescription { get; private set; }
        public string? MetaKeyWords { get; private set; }
        public string? Canonical { get; private set; }
    }
}