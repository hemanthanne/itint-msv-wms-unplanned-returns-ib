

using Lakeshore.SendUnplannedReturn.Domain;

namespace Lakeshore.SendUnplannedReturn.Infrastructure.DomainEventsDispatching
{

    public interface IDomainEventsAccessor
    {
        IReadOnlyCollection<IDomainEvent> GetAllDomainEvents();

        void ClearAllDomainEvents();
    }
}