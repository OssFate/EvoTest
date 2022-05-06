import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient,} from "@angular/common/http";
import {BasePageModel} from "../../model/base-page.model";
import {FormBuilder, FormGroup} from "@angular/forms";
import {GlobalHeader} from "../../global/api-header.global";
import {ReservationModel} from "../../model/data/reservation.model";
import {AirportModel} from "../../model/data/airport.model";
import {AirlineModel} from "../../model/data/airline.model";
import {PassengerTypeModel} from "../../model/data/passenger-type.model";

@Component({
  selector: 'reservation-component',
  templateUrl: './reservation.component.html',
})
export class ReservationComponent implements OnInit, BasePageModel {

  title: string;
  lastInsertId: number;
  itemList: ReservationModel[];
  foundItem: ReservationModel | undefined;
  updatedItem: boolean | undefined;
  deletedItem: ReservationModel | undefined;

  airportOptions: AirportModel[] | undefined;
  airlineOptions: AirlineModel[] | undefined;
  passengerTypeOptions: PassengerTypeModel[] | undefined;

  insertForm: FormGroup;
  findForm: FormGroup;
  updateForm: FormGroup;
  deleteForm: FormGroup;

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string, private fb: FormBuilder) {
    this.title = 'Reservation';
    this.lastInsertId = 0;
    this.itemList = [];

    this.insertForm = this.fb.group({
      origin: '',
      departureTime: '',
      destination: '',
      arrivalTime: '',
      airline: '',
      flyNumber: '',
      passengerType: ''
    });

    this.findForm = this.fb.group({
      id: '',
    });

    this.updateForm = this.fb.group({
      id: '',
      origin: '',
      departureTime: '',
      destination: '',
      arrivalTime: '',
      airline: '',
      flyNumber: '',
      passengerType: ''
    });

    this.deleteForm = this.fb.group({
      id: '',
    });
  }

  ngOnInit() {
    this.getData();

    this.getAirports();
    this.getAirlines();
    this.getPassengerTypes();
  }

  insert() {
    this.httpClient.post(`${this.apiUrl}/reservation/AddReservation`, JSON.stringify(this.insertForm.value), GlobalHeader)
      .subscribe(
        res => {
          this.lastInsertId = res as number;

          this.getData();
        },
        err => {
          console.error(err);
        });
  }

  getData() {
    this.httpClient.get(`${this.apiUrl}/reservation/getAllReservations`)
      .subscribe(
        res => {
          this.itemList = res as ReservationModel[];
        },
        error => {
          console.error(error);
        }
      )
  }

  findItem() {
    const findValue = this.findForm.value;
    this.httpClient.get(`${this.apiUrl}/reservation/getReservation/${findValue.id}`)
      .subscribe(
        res => {
          this.foundItem = res as ReservationModel;
        },
        err => {
          console.error(err);
        }
      )
  }

  update() {
    this.httpClient.put(`${this.apiUrl}/reservation/updateReservation`, this.updateForm.value)
      .subscribe(
        res => {
          this.updatedItem = res as boolean;
          this.getData();

          setTimeout(() => {
            this.updatedItem = undefined;
          }, 5000);
        },
        err => {
          console.error(err);
        }
      )
  }

  delete() {
    const deleteItem = this.deleteForm.value;
    this.httpClient.delete(`${this.apiUrl}/reservation/deleteReservation/${deleteItem.id}`)
      .subscribe(
        res => {
          this.deletedItem = res as ReservationModel;

          this.getData();
        },
        err => {
          console.error(err);
        }
      )
  }

  private getAirports() {
    this.httpClient.get(`${this.apiUrl}/airport/getAllAirports`)
      .subscribe(
        res => {
          this.airportOptions = res as AirportModel[];
        },
        error => {
          console.error(error);
        }
      );
  }

  private getAirlines() {
    this.httpClient.get(`${this.apiUrl}/airline/getAllAirlines`)
      .subscribe(
        res => {
          this.airlineOptions = res as AirlineModel[];
        },
        error => {
          console.error(error);
        }
      );
  }

  private getPassengerTypes() {
    this.httpClient.get(`${this.apiUrl}/passengerType/getAllPassengerTypes`)
      .subscribe(
        res => {
          this.passengerTypeOptions = res as PassengerTypeModel[];
        },
        error => {
          console.error(error);
        }
      );
  }

}
