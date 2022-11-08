using Common.Domain;

namespace BlogModule.Domain;

class Category : BaseEntity
{
    public string Title { get; set; }
    public string Slug { get; set; }
}