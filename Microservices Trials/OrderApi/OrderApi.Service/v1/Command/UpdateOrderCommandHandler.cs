using MediatR;
using OrderAPI.Data.Repository.v1;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace OrderApi.Service.v1.Command
{
    public class UpdateOrderCommandHandler:IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request,CancellationToken cancellationToken)
        {
            await _orderRepository.UpdateRangeAsync(request.Orders);
            return Unit.Value;
        }
    }
}
