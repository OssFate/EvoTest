import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {BasePageModel} from "../../model/base-page.model";

@Component({
  selector: 'airport-component',
  templateUrl: './airport.component.html',
})
export class AirportComponent implements OnInit, BasePageModel {

  title: string;

  constructor(private httpClient: HttpClient) {
    this.title = 'Airport';
  }

  ngOnInit() {
    this.getData();
  }

  getData() {
    this.httpClient.get('https://localhost:44310/api/airline/getAllAirlines')
      .subscribe(res => {
        console.log(res);
      });
  }

}
