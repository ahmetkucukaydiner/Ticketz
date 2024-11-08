using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airlines.Constants;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airlines.Rules;

public class AirlineBusinessRules : BaseBusinessRules
{
    private readonly IAirlineRepository _airlineRepository;

    public AirlineBusinessRules(IAirlineRepository airlineRepository)
    {
        _airlineRepository = airlineRepository;
    }

    public async Task AirlineNameCannotBeDuplicatedWhenInserted(string name)
    {
        Airline? result = await _airlineRepository.GetAsync(x => x.Name == name);

        if (result != null)
        {
            throw new BusinessException(AirlinesMessages.AirlineNameExists);
        }
    }
}
