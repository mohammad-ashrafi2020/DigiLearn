using MongoDB.Driver;

namespace Common.Query.MongoDb;

public static class MongoCollectionQueryByPageExtensions
{
    public static async Task<MongoFilterResult<TDocument>> AggregateByPage<TDocument>(
        this IMongoCollection<TDocument> collection,
        FilterDefinition<TDocument> filterDefinition,
        SortDefinition<TDocument> sortDefinition,
        int page,
        int pageSize)
    {
        var countFacet = AggregateFacet.Create("count",
            PipelineDefinition<TDocument, AggregateCountResult>.Create(new[]
            {
                PipelineStageDefinitionBuilder.Count<TDocument>()
            }));

        var dataFacet = AggregateFacet.Create("data",
            PipelineDefinition<TDocument, TDocument>.Create(new[]
            {
                PipelineStageDefinitionBuilder.Sort(sortDefinition),
                PipelineStageDefinitionBuilder.Skip<TDocument>((page - 1) * pageSize),
                PipelineStageDefinitionBuilder.Limit<TDocument>(pageSize),
            }));


        var aggregation = await collection.Aggregate()
            .Match(filterDefinition)
            .Facet(countFacet, dataFacet)
            .ToListAsync();

        var count = aggregation.First()
            .Facets.First(x => x.Name == "count")
            .Output<AggregateCountResult>()
            ?.FirstOrDefault()
            ?.Count;

        count ??= 0;
        var totalPages = (int)Math.Ceiling((double)count / pageSize);

        var data = aggregation.First()
            .Facets.First(x => x.Name == "data")
            .Output<TDocument>();

        return new MongoFilterResult<TDocument>()
        {
            Data = data,
            PageCount = totalPages,
            EntityCount = count ?? 0
        };
    }
}