using MediatR;
using OrderApi.Service.v1.Command;
using OrderApi.Service.v1.Models;
using OrderApi.Service.v1.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace OrderApi.Service.v1.Services
{
    public class CustomerNameUpdateService : ICustomerNameUpdateService
    {
        private readonly IMediator _mediator;

        public CustomerNameUpdateService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async void UpdateCustomerNameInOrder(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            try 
            {
                var ordersOfCustomer = await _mediator.Send(new GetOrderByCustomerGuidQuery {
                    CustomerId=updateCustomerFullNameModel.Id
                });
                if(ordersOfCustomer.Count!=0)
                {
                    ordersOfCustomer.ForEach(x => x.CustomerFullName = $"{updateCustomerFullNameModel.FirstName} {updateCustomerFullNameModel.LastName}");
                }

                await _mediator.Send(new UpdateOrderCommand
                {
                    Orders=ordersOfCustomer
                });
            }
            catch(Exception ex)
            {
                //log err here
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
