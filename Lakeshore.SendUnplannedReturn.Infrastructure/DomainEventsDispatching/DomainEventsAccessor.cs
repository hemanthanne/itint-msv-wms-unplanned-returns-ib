
using Lakeshore.SendUnplannedReturn.Domain;
using Lakeshore.SendUnplannedReturn.Infrastructure.EntityModelConfiguration;
using Microsoft.EntityFrameworkCore;

namespace Lakeshore.SendUnplannedReturn.Infrastructure.DomainEventsDispatching
{

    public class DomainEventsAccessor : IDomainEventsAccessor
    {
        private readonly DbContext _dbContext;

        public DomainEventsAccessor(UnplannedReturnDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IReadOnlyCollection<IDomainEvent> GetAllDomainEvents()
        {
            var domainEntities = this._dbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            return domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();
        }

        public void ClearAllDomainEvents()
        {
            var domainEntities = this._dbContext.ChangeTracker
                .Entries<Entity>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any()).ToList();

            domainEntities
                .ForEach(entity => entity.Entity.ClearDomainEvents());
        }
    }
}