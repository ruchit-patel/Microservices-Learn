using MediatR;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<CustomerNameUpdateService> _logger;

        public CustomerNameUpdateService(IMediator mediator, ILogger<CustomerNameUpdateService> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async void UpdateCustomerNameInOrder(UpdateCustomerFullNameModel updateCustomerFullNameModel)
        {
            try 
            {
                _logger.LogInformation("Entered method of Update");
                var ordersOfCustomer = await _mediator.Send(new GetOrderByCustomerGuidQuery {
                    CustomerId=updateCustomerFullNameModel.Id
                });
                if(ordersOfCustomer.Count!=0)
                {
                    _logger.LogInformation("Entered loop of Update");
                    ordersOfCustomer.ForEach(x => x.CustomerFullName = $"{updateCustomerFullNameModel.FirstName} {updateCustomerFullNameModel.LastName}");
                }

                await _mediator.Send(new UpdateOrderCommand
                {
                    Orders=ordersOfCustomer
                });
                _logger.LogInformation("Exited loop of Update");
            }
            catch(Exception ex)
            {
                //log err here
                _logger.LogError("Error occured... shit1!!!!!");
                _logger.LogError(ex.Message);
                Debug.WriteLine(ex.Message);
            }
        }
    }
}
