using EvoTest.Api.Data.EntityModel;

namespace EvoTest.Api.Services.Interface;

public interface IReservationService
{
    Task<int> AddReservation(Reservation reservation);
    Task<List<Reservation>> GetAllReservations();
    Task<Reservation?> GetReservationById(int reservationId);
    Task<Reservation?> DeleteReservation(int reservationId);
    Task<bool> UpdateReservation(Reservation reservation);
}