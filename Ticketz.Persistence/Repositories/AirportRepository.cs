using AutoMapper;
using Core.Persistance.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketz.Application.Features.Airports.Queries.SearchAirports;
using Ticketz.Application.Services.Repositories;
using Ticketz.Domain.Entities;
using Ticketz.Persistence.Context;

namespace Ticketz.Persistence.Repositories;

public class AirportRepository : EfRepositoryBase<Airport, int, BaseDbContext>, IAirportRepository
{
    private readonly IMapper _mapper;    

    public AirportRepository(BaseDbContext context, IMapper mapper) : base(context)
    {
        _mapper = mapper;
    }

    public async Task<List<SearchAirportsQueryResponse>> SearchAirportsAsync(string searchTerm)
    {
        IQueryable<Airport> query = Context.Set<Airport>();

        if (string.IsNullOrWhiteSpace(searchTerm))
        {
            var popularAirports = await query
                .OrderByDescending(a => a.Name)
                .Take(10)
                .ToListAsync();

            // Debug için
            var mapped = _mapper.Map<List<SearchAirportsQueryResponse>>(popularAirports);
            foreach (var airport in popularAirports)
            {
                var mappedAirport = mapped.FirstOrDefault(m => m.AirportCode == airport.AirportCode.ToString());
                if (mappedAirport?.AirportCode != airport.AirportCode)
                {
                    // Log the difference
                    System.Diagnostics.Debug.WriteLine($"Mapping mismatch for airport {airport.Id}:");
                    System.Diagnostics.Debug.WriteLine($"Original: {airport.AirportCode}");
                    System.Diagnostics.Debug.WriteLine($"Mapped: {mappedAirport?.AirportCode}");
                }
            }

            return mapped;
        }

        searchTerm = searchTerm.Trim().ToUpper();

        var airports = await query
            .Where(a =>
                       (EF.Functions.Like(a.AirportCode, $"%{searchTerm}%") ||
                        EF.Functions.Like(a.City, $"%{searchTerm}%") ||
                        EF.Functions.Like(a.Name, $"%{searchTerm}%")))
            .OrderByDescending(a =>
                (a.AirportCode == searchTerm ? 1 : 0))
            .ThenByDescending(a => a.Name)
            .Take(10)
            .ToListAsync();

        // Debug için
        var mappedResults = _mapper.Map<List<SearchAirportsQueryResponse>>(airports);
        foreach (var airport in airports)
        {
            var mappedAirport = mappedResults.FirstOrDefault(m => m.AirportCode == airport.AirportCode.ToString());
            if (mappedAirport?.AirportCode != airport.AirportCode)
            {
                // Log the difference
                System.Diagnostics.Debug.WriteLine($"Mapping mismatch for airport {airport.Id}:");
                System.Diagnostics.Debug.WriteLine($"Original: {airport.AirportCode}");
                System.Diagnostics.Debug.WriteLine($"Mapped: {mappedAirport?.AirportCode}");
            }
        }

        return mappedResults;
    }
}
