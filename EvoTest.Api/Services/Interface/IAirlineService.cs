using EvoTest.Api.Data.EntityModel;

namespace EvoTest.Api.Services.Interface;

public interface IAirlineService
{
    Task<int> AddAirline(AirLine airline);
    Task<List<AirLine>> GetAllAirlines();
    Task<AirLine?> GetAirlineById(int airlineId);
    Task<bool> UpdateAirline(AirLine airline);
    Task<AirLine?> DeleteAirline(int airlineId);
}