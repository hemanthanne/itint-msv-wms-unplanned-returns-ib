using Lakeshore.SendUnplannedReturn.Dto.SendUnplannedReturn;
using MediatR;
using System.Text.Json;

namespace Lakeshore.SendUnplannedReturn.Domain.Har.Events
{

    public class UnplannedReturnUpdatedDomainEvent : IDomainEvent
    {
        public UnplannedReturnDto unplannedReturn { get; }

        public Guid Id => new Guid();

        public DateTime OccurredOn => DateTime.Now;

        public string NotificationJson => JsonSerializer.Serialize(unplannedReturn);

        public UnplannedReturnUpdatedDomainEvent(UnplannedReturnDto unplannedReturn)
        {
            this.unplannedReturn = unplannedReturn;
        }
    }
}
