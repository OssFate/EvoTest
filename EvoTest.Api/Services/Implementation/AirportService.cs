using EvoTest.Api.Data;
using EvoTest.Api.Data.EntityModel;
using EvoTest.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EvoTest.Api.Services.Implementation;

public class AirportService: IAirportService
{
    private readonly AirportContext _airportContext;

    public AirportService(AirportContext airportContext)
    {
        _airportContext = airportContext;
    }

    public async Task<int> AddAirport(Airport airport)
    {
        airport.Id = 0;
        await _airportContext.Airports.AddAsync(airport);
        await _airportContext.SaveChangesAsync();

        return airport.Id;
    }

    public async Task<List<Airport>> GetAllAirports()
    {
        var result = await _airportContext.Airports.ToListAsync();
        return result;
    }

    public async Task<Airport?> GetAirportById(int airportId)
    {
        var result = await _airportContext.Airports.Where(a => a.Id == airportId).FirstOrDefaultAsync();
        return result;
    }

    public async Task<bool> UpdateAirport(Airport airport)
    {
        if (airport.Id == 0) return false;
        
        _airportContext.Airports.Update(airport);
        var result = await _airportContext.SaveChangesAsync();
        
        return result > 0;
    }

    public async Task<Airport?> DeleteAirport(int airportId)
    {
        var airport = await _airportContext.Airports.Where(a => a.Id == airportId).FirstOrDefaultAsync();
        if (airport == null) return null;

        _airportContext.Airports.Remove(airport);
        await _airportContext.SaveChangesAsync();

        return airport;
    }
}