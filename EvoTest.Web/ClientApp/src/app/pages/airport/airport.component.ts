import {Component, Inject, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BasePageModel} from "../../model/base-page.model";
import {FormBuilder, FormGroup} from "@angular/forms";
import {AirportModel} from "../../model/data/airport.model";
import {GlobalHeader} from "../../global/api-header.global";

@Component({
  selector: 'airport-component',
  templateUrl: './airport.component.html',
})
export class AirportComponent implements OnInit, BasePageModel {

  title: string;
  lastInsertId: number;
  itemList: AirportModel[];
  foundItem: AirportModel | undefined;
  updatedItem: boolean | undefined;
  deletedItem: AirportModel | undefined;

  insertForm: FormGroup;
  findForm: FormGroup;
  updateForm: FormGroup;
  deleteForm: FormGroup;

  constructor(private httpClient: HttpClient, @Inject('API_URL') private apiUrl: string, private fb: FormBuilder) {
    this.title = 'Airport';
    this.lastInsertId = 0;
    this.itemList = [];

    this.insertForm = this.fb.group({
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
    this.httpClient.post(`${this.apiUrl}/airport/AddAirport`, JSON.stringify(this.insertForm.value), GlobalHeader)
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
    this.httpClient.get(`${this.apiUrl}/airport/getAllAirports`)
      .subscribe(
        res => {
          this.itemList = res as AirportModel[];
        },
        error => {
          console.error(error);
        }
      )
  }

  findItem() {
    const findValue = this.findForm.value;
    this.httpClient.get(`${this.apiUrl}/airport/getAirport/${findValue.id}`)
      .subscribe(
        res => {
          this.foundItem = res as AirportModel;
        },
        err => {
          console.error(err);
        }
      )
  }

  update() {
    this.httpClient.put(`${this.apiUrl}/airport/updateAirport`, this.updateForm.value)
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
    this.httpClient.delete(`${this.apiUrl}/airport/deleteAirport/${deleteItem.id}`)
      .subscribe(
        res => {
          this.deletedItem = res as AirportModel;

          this.getData();
        },
        err => {
          console.error(err);
        }
      )
  }

}
