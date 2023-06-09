using Lakeshore.SendUnplannedReturn.Domain.Har.Events;
using Lakeshore.Kafka.Client.Interfaces;
using MediatR;
using System.Text.Json;
using Confluent.Kafka;


namespace Lakeshore.SendUnplannedReturn.Application.Har.DomainEventHandlers
{

    public class UnplannedReturnUpdatedDomainEventHandler : INotificationHandler<UnplannedReturnUpdatedDomainEvent>
    {
        private readonly IKafkaProducerClient _kafkaProducerClient;

        public UnplannedReturnUpdatedDomainEventHandler(IKafkaProducerClient kafkaProducerClient)
        {
            _kafkaProducerClient = kafkaProducerClient ?? throw new ArgumentNullException(nameof(kafkaProducerClient));
        }
        public async Task Handle(UnplannedReturnUpdatedDomainEvent notification, CancellationToken cancellationToken)
        {
            string strJson = JsonSerializer.Serialize(notification.unplannedReturn);
            await _kafkaProducerClient.Producer.ProduceAsync(_kafkaProducerClient.Topic, new Message<Null, string> { Value = strJson }, cancellationToken);
        }
    }
}
