﻿using System.Threading.Tasks;
using MediatR;
using Sakamoto.TCC2.CSU.Domain.Core.Bus;
using Sakamoto.TCC2.CSU.Domain.Core.Commands;
using Sakamoto.TCC2.CSU.Domain.Core.Events;
using Sakamoto.TCC2.CSU.Domain.Core.Events.Interfaces;

namespace Sakamoto.TCC2.CSU.Practitioners.Infrastructure.CrossCutting.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IEventStore _eventStore;
        private readonly IMediator _mediator;

        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task RaiseEvent<T>(T @event) where T : Event
        {
            //if (!@event.MessageType.Equals("DomainNotification"))
            //    _eventStore?.Save(@event);

            return _mediator.Publish(@event);
        }

        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}