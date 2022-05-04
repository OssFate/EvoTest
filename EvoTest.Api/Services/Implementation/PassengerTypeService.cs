using EvoTest.Api.Data;
using EvoTest.Api.Data.EntityModel;
using EvoTest.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EvoTest.Api.Services.Implementation;

public class PassengerTypeService: IPassengerTypeService
{
    private readonly AirportContext _airportContext;

    public PassengerTypeService(AirportContext airportContext)
    {
        _airportContext = airportContext;
    }

    public async Task<int> AddPassengerType(PassengerType passengerType)
    {
        passengerType.Id = 0;
        await _airportContext.PassengerTypes.AddAsync(passengerType);
        await _airportContext.SaveChangesAsync();

        return passengerType.Id;
    }

    public async Task<List<PassengerType>> GetAllPassengerTypes()
    {
        var result = await _airportContext.PassengerTypes.ToListAsync();
        return result;
    }

    public async Task<PassengerType?> GetPassengerTypeById(int passengerTypeId)
    {
        var result = await _airportContext.PassengerTypes.Where(a => a.Id == passengerTypeId).FirstOrDefaultAsync();
        return result;
    }

    public async Task<bool> UpdatePassengerType(PassengerType passengerType)
    {
        if (passengerType.Id == 0) return false;
        
        _airportContext.PassengerTypes.Update(passengerType);
        var result = await _airportContext.SaveChangesAsync();
        
        return result > 0;
    }

    public async Task<PassengerType?> DeletePassengerType(int passengerTypeId)
    {
        var passengerType = await _airportContext.PassengerTypes.Where(a => a.Id == passengerTypeId).FirstOrDefaultAsync();
        if (passengerType == null) return null;

        _airportContext.PassengerTypes.Remove(passengerType);
        await _airportContext.SaveChangesAsync();

        return passengerType;
    }
}