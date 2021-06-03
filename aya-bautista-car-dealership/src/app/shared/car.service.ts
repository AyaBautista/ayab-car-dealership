import { Injectable } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Car } from './car.model';
import { CarFilter } from './car-filter.model';
import { HttpClient, HttpParams } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CarService {

  filterData : CarFilter;

  gridData : Car[] = [];

  readonly rootURL = "http://localhost:56972/api"

  constructor(private httpClient: HttpClient) { }

  getCars(filterFormData: CarFilter) {
    this.gridData = [];

    const params = new HttpParams()
      .set('Color', filterFormData.Color)
      .set('HasHeatedSeats', filterFormData.HasHeatedSeats ? 'true' : 'false')
      .set('HasLowMiles', filterFormData.HasLowMiles ? 'true' : 'false')
      .set('HasNavigation', filterFormData.HasNavigation ? 'true' : 'false')
      .set('HasPowerWindows', filterFormData.HasPowerWindows ? 'true' : 'false')
      .set('HasSunroof', filterFormData.HasSunroof ? 'true' : 'false')
      .set('IsFourWheelDrive', filterFormData.IsFourWheelDrive ? 'true' : 'false')
      .set('ShowExactMatches', filterFormData.ShowExactMatches ? 'true' : 'false');

    return this.httpClient.get(this.rootURL + '/Car', { params })
      .toPromise().then(resp => {
        console.warn(resp);
        this.gridData = resp as Car[];
      }).catch(err => {
        alert(err.error.ExceptionMessage);
      });
  }
}
