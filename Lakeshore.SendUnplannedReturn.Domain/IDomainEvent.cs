using System;
using MediatR;

namespace Lakeshore.SendUnplannedReturn.Domain;

public interface IDomainEvent : INotification
{
    Guid Id { get; }

    DateTime OccurredOn { get; }

    string NotificationJson { get; }
}