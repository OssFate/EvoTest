import {Component, OnInit} from '@angular/core';
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private httpClient: HttpClient) {
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
