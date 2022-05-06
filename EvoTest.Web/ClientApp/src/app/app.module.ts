import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {FormsModule, ReactiveFormsModule} from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './pages/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/home/home.component';
import {AirportComponent} from "./pages/airport/airport.component";
import {AirlineComponent} from "./pages/airline/airline.component";
import {PassengerTypeComponent} from "./pages/passenger-type/passenger-type.component";
import {ReservationComponent} from "./pages/reservation/reservation.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AirportComponent,
    AirlineComponent,
    PassengerTypeComponent,
    ReservationComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full'},
      {path: 'airport', component: AirportComponent},
      {path: 'airline', component: AirlineComponent},
      {path: 'passengerType', component: PassengerTypeComponent},
      {path: 'reservation', component: ReservationComponent}
    ]),
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
