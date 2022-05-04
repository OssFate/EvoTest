using EvoTest.Api.Data.EntityModel;

namespace EvoTest.Api.Services.Interface;

public interface IPassengerTypeService
{
    Task<int> AddPassengerType(PassengerType passengerType);
    Task<List<PassengerType>> GetAllPassengerTypes();
    Task<PassengerType?> GetPassengerTypeById(int passengerTypeId);
    Task<bool> UpdatePassengerType(PassengerType passengerType);
    Task<PassengerType?> DeletePassengerType(int passengerTypeId);
}