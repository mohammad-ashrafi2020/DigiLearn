namespace Common.Query.MongoDb;

public class MongoFilterResult<T>
{
    public int PageCount { get; set; }
    public long EntityCount { get; set; }
    public IReadOnlyList<T> Data { get; set; }
}