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
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Users.Queries.GetById;

public class GetByIdUserQuery : IRequest<GetByIdUserResponse>, ILoggableRequest, ICachableRequest
{
    public int Id { get; set; }
    public string CacheKey => "GetByIdUserQuery";
    public bool BypassCache { get; }
    public string? CacheGroupKey => "GetUser";
    public TimeSpan? SlidingExpiration { get; }

    public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, GetByIdUserResponse>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetByIdUserResponse> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            User? user = await _userRepository.GetAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);

            GetByIdUserResponse getByIdUserResponse = _mapper.Map<GetByIdUserResponse>(user);

            return getByIdUserResponse;
        }
    }
}
