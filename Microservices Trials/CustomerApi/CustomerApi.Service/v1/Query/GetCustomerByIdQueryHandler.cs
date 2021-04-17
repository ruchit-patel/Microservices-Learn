﻿using CustomerApi.Data.Repository.v1;
using CustomerApi.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Service.v1.Query
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQuery, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(request.Id, cancellationToken);
        }
    }
}
