import {AirportModel} from "./airport.model";
import {AirlineModel} from "./airline.model";
import {PassengerTypeModel} from "./passenger-type.model";

export interface ReservationModel {
  id: number;
  origin: AirportModel;
  departureTime: Date;
  destination: AirportModel;
  arrivalTime: Date;
  airLine: AirlineModel;
  flyNumber: string;
  passengerType: PassengerTypeModel;
}
