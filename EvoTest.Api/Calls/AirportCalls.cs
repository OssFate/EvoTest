using EvoTest.Api.Data.EntityModel;
using EvoTest.Api.Services.Interface;

namespace EvoTest.Api.Calls;

public static class AirportCalls
{
    public static void SetCalls(WebApplication app)
    {
        SetAirlineCrud(app);
        SetAirportCrud(app);
        SetPassengerTypeCrud(app);
        SetReservationCrud(app);
    }

    private static void SetReservationCrud(IEndpointRouteBuilder app)
    {
        const string baseApiUrl = "api/reservation";
        const string baseApiTag = "Reservation";

        app.MapPost($"{baseApiUrl}/AddReservation",
                async (Reservation reservation, IReservationService reservationService) =>
                    await reservationService.AddReservation(reservation))
            .WithTags(baseApiTag);

        app.MapGet($"{baseApiUrl}/getAllReservations",
                async (IReservationService reservationService) => await reservationService.GetAllReservations())
            .WithTags(baseApiTag);

        app.MapGet(baseApiUrl + "/getReservation/{reservationId:int}",
                async (int reservationId, IReservationService reservationService) =>
                    await reservationService.GetReservationById(reservationId))
            .WithTags(baseApiTag);

        app.MapPut($"{baseApiUrl}/updateReservation",
                async (Reservation reservation, IReservationService reservationService) =>
                    await reservationService.UpdateReservation(reservation))
            .WithTags(baseApiTag);

        app.MapDelete(baseApiUrl + "/deleteReservation/{reservationId:int}",
                async (int reservationId, IReservationService reservationService) =>
                    await reservationService.DeleteReservation(reservationId))
            .WithTags(baseApiTag);
    }

    private static void SetAirlineCrud(IEndpointRouteBuilder app)
    {
        const string baseApiUrl = "api/airline";
        const string baseApiTag = "Airline";

        app.MapPost($"{baseApiUrl}/AddAirline",
                async (AirLine airline, IAirlineService airlineService) =>
                    await airlineService.AddAirline(airline))
            .WithTags(baseApiTag);

        app.MapGet($"{baseApiUrl}/getAllAirlines",
                async (IAirlineService airlineService) => await airlineService.GetAllAirlines())
            .WithTags(baseApiTag);

        app.MapGet(baseApiUrl + "/getAirline/{airlineId:int}",
                async (int airlineId, IAirlineService airlineService) =>
                    await airlineService.GetAirlineById(airlineId))
            .WithTags(baseApiTag);

        app.MapPut($"{baseApiUrl}/updateAirline",
                async (AirLine airline, IAirlineService airlineService) =>
                    await airlineService.UpdateAirline(airline))
            .WithTags(baseApiTag);

        app.MapDelete(baseApiUrl + "/deleteAirline/{airlineId:int}",
                async (int airlineId, IAirlineService airlineService) =>
                    await airlineService.DeleteAirline(airlineId))
            .WithTags(baseApiTag);
    }
    
    private static void SetAirportCrud(IEndpointRouteBuilder app)
    {
        const string baseApiUrl = "api/airport";
        const string baseApiTag = "Airport";

        app.MapPost($"{baseApiUrl}/AddAirport",
                async (Airport airport, IAirportService airportService) =>
                    await airportService.AddAirport(airport))
            .WithTags(baseApiTag);

        app.MapGet($"{baseApiUrl}/getAllAirports",
                async (IAirportService airportService) => await airportService.GetAllAirports())
            .WithTags(baseApiTag);

        app.MapGet(baseApiUrl + "/getAirport/{airportId:int}",
                async (int airportId, IAirportService airportService) =>
                    await airportService.GetAirportById(airportId))
            .WithTags(baseApiTag);

        app.MapPut($"{baseApiUrl}/updateAirport",
                async (Airport airport, IAirportService airportService) =>
                    await airportService.UpdateAirport(airport))
            .WithTags(baseApiTag);

        app.MapDelete(baseApiUrl + "/deleteAirport/{airportId:int}",
                async (int airportId, IAirportService airportService) =>
                    await airportService.DeleteAirport(airportId))
            .WithTags(baseApiTag);
    }
    
    private static void SetPassengerTypeCrud(IEndpointRouteBuilder app)
    {
        const string baseApiUrl = "api/passengerType";
        const string baseApiTag = "PassengerType";

        app.MapPost($"{baseApiUrl}/AddPassengerType",
                async (PassengerType passengerType, IPassengerTypeService passengerTypeService) =>
                    await passengerTypeService.AddPassengerType(passengerType))
            .WithTags(baseApiTag);

        app.MapGet($"{baseApiUrl}/getAllPassengerTypes",
                async (IPassengerTypeService passengerTypeService) => await passengerTypeService.GetAllPassengerTypes())
            .WithTags(baseApiTag);

        app.MapGet(baseApiUrl + "/getPassengerType/{passengerTypeId:int}",
                async (int passengerTypeId, IPassengerTypeService passengerTypeService) =>
                    await passengerTypeService.GetPassengerTypeById(passengerTypeId))
            .WithTags(baseApiTag);

        app.MapPut($"{baseApiUrl}/updatePassengerType",
                async (PassengerType passengerType, IPassengerTypeService passengerTypeService) =>
                    await passengerTypeService.UpdatePassengerType(passengerType))
            .WithTags(baseApiTag);

        app.MapDelete(baseApiUrl + "/deletePassengerType/{passengerTypeId:int}",
                async (int passengerTypeId, IPassengerTypeService passengerTypeService) =>
                    await passengerTypeService.DeletePassengerType(passengerTypeId))
            .WithTags(baseApiTag);
    }

}