import { Component, OnInit } from '@angular/core';
import { CarService } from 'src/app/shared/car.service';

@Component({
  selector: 'app-car-grid',
  templateUrl: './car-grid.component.html',
  styleUrls: ['./car-grid.component.css']
})
export class CarGridComponent implements OnInit {

  constructor(private carService: CarService) { }

  ngOnInit() {
    
  }

}
