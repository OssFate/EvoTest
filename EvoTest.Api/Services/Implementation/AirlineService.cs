using EvoTest.Api.Data;
using EvoTest.Api.Data.EntityModel;
using EvoTest.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EvoTest.Api.Services.Implementation;

public class AirlineService: IAirlineService
{
    private readonly AirportContext _airportContext;

    public AirlineService(AirportContext airportContext)
    {
        _airportContext = airportContext;
    }

    public async Task<int> AddAirline(AirLine airline)
    {
        airline.Id = 0;
        await _airportContext.AirLines.AddAsync(airline);
        await _airportContext.SaveChangesAsync();

        return airline.Id;
    }

    public async Task<List<AirLine>> GetAllAirlines()
    {
        var result = await _airportContext.AirLines.ToListAsync();
        return result;
    }

    public async Task<AirLine?> GetAirlineById(int airlineId)
    {
        var result = await _airportContext.AirLines.Where(a => a.Id == airlineId).FirstOrDefaultAsync();
        return result;
    }

    public async Task<bool> UpdateAirline(AirLine airline)
    {
        if (airline.Id == 0) return false;
        
        _airportContext.AirLines.Update(airline);
        var result = await _airportContext.SaveChangesAsync();
        
        return result > 0;
    }

    public async Task<AirLine?> DeleteAirline(int airlineId)
    {
        var airline = await _airportContext.AirLines.Where(a => a.Id == airlineId).FirstOrDefaultAsync();
        if (airline == null) return null;

        _airportContext.AirLines.Remove(airline);
        await _airportContext.SaveChangesAsync();

        return airline;
    }
}