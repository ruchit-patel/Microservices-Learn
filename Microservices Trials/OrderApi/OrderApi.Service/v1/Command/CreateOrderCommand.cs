using OrderApi.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Service.v1.Command
{
    public class CreateOrderCommand : IRequest<Order>
    {
        public Order Order { get; set; }
    }
}
