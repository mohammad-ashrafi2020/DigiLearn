using Common.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Common.Infrastructure
{
    public class BaseEfContext<T> : DbContext where T : DbContext
    {
        private readonly IMediator _mediator;
        public BaseEfContext(DbContextOptions<T> options, IMediator mediator) : base(options)
        {
            _mediator = mediator;
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
        {
            var modifiedEntities = GetModifiedEntities();
            var res = await base.SaveChangesAsync(cancellationToken);
            await PublishEvents(modifiedEntities);
            return res;
        }
        private List<AggregateRoot> GetModifiedEntities() =>
            ChangeTracker.Entries<AggregateRoot>()
                .Where(x => x.State != EntityState.Detached)
                .Select(c => c.Entity)
                .Where(c => c.DomainEvents.Any()).ToList();

        private async Task PublishEvents(List<AggregateRoot> modifiedEntities)
        {
            foreach (var entity in modifiedEntities)
            {
                var events = entity.DomainEvents;
                foreach (var domainEvent in events)
                {
                    await _mediator.Publish(domainEvent);
                }
            }
        }
    }
}
