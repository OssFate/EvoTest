using EvoTest.Api.Data.EntityModel;

namespace EvoTest.Api.Services.Interface;

public interface IAirportService
{
    Task<int> AddAirport(Airport airport);
    Task<List<Airport>> GetAllAirports();
    Task<Airport?> GetAirportById(int airportId);
    Task<bool> UpdateAirport(Airport airport);
    Task<Airport?> DeleteAirport(int airportId);
}