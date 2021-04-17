using MediatR;
using OrderApi.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderApi.Service.v1.Query
{
    public class GetOrderByCustomerGuidQuery:IRequest<List<Order>>
    {
        public Guid CustomerId { get; set; }
    }
}
