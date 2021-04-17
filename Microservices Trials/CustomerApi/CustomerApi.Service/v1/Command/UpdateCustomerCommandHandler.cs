using CustomerApi.Data.Repository.v1;
using CustomerApi.Domain;
using CustomerApi.Messaging.Send.Sender.v1;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Service.v1.Command
{
    public class UpdateCustomerCommandHandler: IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ICustomerUpdateSender _customerUpdateSender;

        public UpdateCustomerCommandHandler(ICustomerUpdateSender customerUpdateSender, ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
            _customerUpdateSender = customerUpdateSender;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.UpdateAsync(request.Customer);
            _customerUpdateSender.SendCustomer(customer);
            return customer;
        }

    }
}
