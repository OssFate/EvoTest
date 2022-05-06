import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BasePageModel} from "../../model/base-page.model";
import {FormBuilder, FormGroup} from "@angular/forms";
import {GlobalHeader} from "../../global/api-header.global";
import {PassengerTypeModel} from "../../model/data/passenger-type.model";

@Component({
  selector: 'passenger-type-component',
  templateUrl: './passenger-type.component.html',
})
export class PassengerTypeComponent implements OnInit, BasePageModel {

  title: string;
  lastInsertId: number;
  itemList: PassengerTypeModel[];
  foundItem: PassengerTypeModel | undefined;
  updatedItem: boolean | undefined;
  deletedItem: PassengerTypeModel | undefined;

  insertForm: FormGroup;
  findForm: FormGroup;
  updateForm: FormGroup;
  deleteForm: FormGroup;

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string, private fb: FormBuilder) {
    this.title = 'Passenger Type';
    this.lastInsertId = 0;
    this.itemList = [];

    this.insertForm = this.fb.group({
      name: '',
      price: '',
    });

    this.findForm = this.fb.group({
      id: '',
    });

    this.updateForm = this.fb.group({
      id: '',
      name: '',
      price: '',
    });

    this.deleteForm = this.fb.group({
      id: '',
    });
  }

  ngOnInit() {
    this.getData();
  }

  insert() {
    this.httpClient.post(`${this.apiUrl}/passengerType/AddPassengerType`, JSON.stringify(this.insertForm.value), GlobalHeader)
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
    this.httpClient.get(`${this.apiUrl}/passengerType/getAllPassengerTypes`)
      .subscribe(
        res => {
          this.itemList = res as PassengerTypeModel[];
        },
        error => {
          console.error(error);
        }
      )
  }

  findItem() {
    const findValue = this.findForm.value;
    this.httpClient.get(`${this.apiUrl}/passengerType/getPassengerType/${findValue.id}`)
      .subscribe(
        res => {
          this.foundItem = res as PassengerTypeModel;
        },
        err => {
          console.error(err);
        }
      )
  }

  update() {
    this.httpClient.put(`${this.apiUrl}/passengerType/updatePassengerType`, this.updateForm.value)
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
    this.httpClient.delete(`${this.apiUrl}/passengerType/deletePassengerType/${deleteItem.id}`)
      .subscribe(
        res => {
          this.deletedItem = res as PassengerTypeModel;

          this.getData();
        },
        err => {
          console.error(err);
        }
      )
  }

}
