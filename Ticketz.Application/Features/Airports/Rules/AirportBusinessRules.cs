using Core.Application.Rules;
using Core.CrossCuttingConcerns.Exceptions.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airports.Constants;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;

namespace Ticketz.Application.Features.Airports.Rules;

public class AirportBusinessRules : BaseBusinessRules
{
    private readonly IAirportRepository _airportRepository;
    public AirportBusinessRules(IAirportRepository airportRepository)
    {
        _airportRepository = airportRepository;
    }

    public async Task AirportNameCannotBeDuplicatedWhenInserted(string name)
    {
        Airport? result = await _airportRepository.GetAsync(a => a.Name.ToLower() == name.ToLower());

        if (result != null)
        {
            throw new BusinessException(AirportsMessages.AirportNameExists);
        }
    }
}
