import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CarService } from 'src/app/shared/car.service';
import { Car } from '../../shared/car.model';

@Component({
  selector: 'app-car-filter',
  templateUrl: './car-filter.component.html',
  styleUrls: ['./car-filter.component.css']
})
export class CarFilterComponent implements OnInit {

  constructor(private carService : CarService) { }

  ngOnInit() {
    this.resetFilter();
  }

  onSubmit(filterForm: NgForm) {
    this.carService.getCars(filterForm.value);
  }

  resetFilter() {
    this.carService.filterData = {
      Color: '',
      HasSunroof: false,
      IsFourWheelDrive: false,
      HasLowMiles: false,
      HasPowerWindows: false,
      HasNavigation: false,
      HasHeatedSeats: false,
      ShowExactMatches: false
    }    
  }
}
