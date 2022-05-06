import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BasePageModel} from "../../model/base-page.model";
import {FormBuilder, FormGroup} from "@angular/forms";
import {GlobalHeader} from "../../global/api-header.global";
import {AirlineModel} from "../../model/data/airline.model";

@Component({
  selector: 'airline-component',
  templateUrl: './airline.component.html',
})
export class AirlineComponent implements OnInit, BasePageModel {

  title: string;
  lastInsertId: number;
  itemList: AirlineModel[];
  foundItem: AirlineModel | undefined;
  updatedItem: boolean | undefined;
  deletedItem: AirlineModel | undefined;

  insertForm: FormGroup;
  findForm: FormGroup;
  updateForm: FormGroup;
  deleteForm: FormGroup;

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string, private fb: FormBuilder) {
    this.title = 'Airline';
    this.lastInsertId = 0;
    this.itemList = [];

    this.insertForm = this.fb.group({
      id: 0,
      name: '',
    });

    this.findForm = this.fb.group({
      id: '',
    });

    this.updateForm = this.fb.group({
      id: '',
      name: '',
    });

    this.deleteForm = this.fb.group({
      id: '',
    });
  }

  ngOnInit() {
    this.getData();
  }

  insert() {
    this.httpClient.post(`${this.apiUrl}/airline/AddAirline`, JSON.stringify(this.insertForm.value), GlobalHeader)
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
    this.httpClient.get(`${this.apiUrl}/airline/getAllAirlines`)
      .subscribe(
        res => {
          this.itemList = res as AirlineModel[];
        },
        error => {
          console.error(error);
        }
      )
  }

  findItem() {
    const findValue = this.findForm.value;
    this.httpClient.get(`${this.apiUrl}/airline/getAirline/${findValue.id}`)
      .subscribe(
        res => {
          this.foundItem = res as AirlineModel;
        },
        err => {
          console.error(err);
        }
      )
  }

  update() {
    this.httpClient.put(`${this.apiUrl}/airline/updateAirline`, this.updateForm.value)
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
    this.httpClient.delete(`${this.apiUrl}/airline/deleteAirline/${deleteItem.id}`)
      .subscribe(
        res => {
          this.deletedItem = res as AirlineModel;

          this.getData();
        },
        err => {
          console.error(err);
        }
      )
  }

}
