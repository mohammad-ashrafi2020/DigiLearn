using Common.Query.Filter;
using MediatR;

namespace Common.Query;

public interface IQuery<TResponse> : IRequest<TResponse>
{
}

public class QueryFilter<TResponse, TParam> : IQuery<TResponse>
    where TResponse : BaseFilter
    where TParam : BaseFilterParam
{
    public TParam FilterParams { get; set; }
    public QueryFilter(TParam filterParams)
    {
        FilterParams = filterParams;
    }
}