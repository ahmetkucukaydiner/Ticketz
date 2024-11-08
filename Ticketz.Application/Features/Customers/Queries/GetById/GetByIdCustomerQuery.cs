using AutoMapper;
using Core.Application.Pipelines.Caching;
using Core.Application.Pipelines.Logging;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Services.Repositories;

namespace Ticketz.Application.Features.Customers.Queries.GetById;

public class GetByIdCustomerQuery : IRequest<GetByIdCustomerResponse>, ILoggableRequest, ICachableRequest
{
    public int Id { get; set; }

    public string CacheKey => "GetByIdCustomerQuery";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetCustomer";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByIdCustomerQueryHandler : IRequestHandler<GetByIdCustomerQuery, GetByIdCustomerResponse>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetByIdCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdCustomerResponse> Handle(GetByIdCustomerQuery request, CancellationToken cancellationToken)
        {
            Domain.Entities.Customer? customer = await _customerRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdCustomerResponse getByIdCustomerResponse = _mapper.Map<GetByIdCustomerResponse>(customer);

            return getByIdCustomerResponse;
        }
    }
}
