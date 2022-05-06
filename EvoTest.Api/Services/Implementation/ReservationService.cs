using EvoTest.Api.Data;
using EvoTest.Api.Data.EntityModel;
using EvoTest.Api.Services.Interface;
using Microsoft.EntityFrameworkCore;

namespace EvoTest.Api.Services.Implementation;

public class ReservationService: IReservationService
{
    private readonly AirportContext _airportContext;

    public ReservationService(AirportContext airportContext)
    {
        _airportContext = airportContext;
    }

    public async Task<int> AddReservation(Reservation reservation)
    {
        reservation.Id = 0;

        reservation.Origin = await _airportContext.Airports.Where(a => a.Id == reservation.Origin.Id).FirstAsync();
        reservation.Destination = await _airportContext.Airports.Where(a => a.Id == reservation.Destination.Id).FirstAsync();
        reservation.AirLine = await _airportContext.AirLines.Where(a => a.Id == reservation.AirLine.Id).FirstAsync();
        reservation.PassengerType = await _airportContext.PassengerTypes.Where(a => a.Id == reservation.PassengerType.Id).FirstAsync();

        await _airportContext.Reservations.AddAsync(reservation);
        await _airportContext.SaveChangesAsync();

        return reservation.Id;
    }

    public async Task<List<Reservation>> GetAllReservations()
    {
        var result = await _airportContext.Reservations
            .Include(i => i.Origin)
            .Include(i => i.Destination)
            .Include(i => i.AirLine)
            .Include(i => i.PassengerType)
            .ToListAsync();
        return result;
    }

    public async Task<Reservation?> GetReservationById(int reservationId)
    {
        var result = await _airportContext.Reservations
            .Include(i => i.Origin)
            .Include(i => i.Destination)
            .Include(i => i.AirLine)
            .Include(i => i.PassengerType)
            .Where(a => a.Id == reservationId)
            .FirstOrDefaultAsync();
        return result;
    }

    public async Task<Reservation?> DeleteReservation(int reservationId)
    {
        var reservation = await _airportContext.Reservations
            .Include(i => i.Origin)
            .Include(i => i.Destination)
            .Include(i => i.AirLine)
            .Include(i => i.PassengerType)
            .Where(a => a.Id == reservationId).FirstOrDefaultAsync();
        
        if (reservation == null) return null;

        _airportContext.Reservations.Remove(reservation);
        await _airportContext.SaveChangesAsync();

        return reservation;
    }

    public async Task<bool> UpdateReservation(Reservation reservation)
    {
        if (reservation.Id == 0) return false;
        
        _airportContext.Reservations.Update(reservation);
        var result = await _airportContext.SaveChangesAsync();
        
        return result > 0;
    }
}