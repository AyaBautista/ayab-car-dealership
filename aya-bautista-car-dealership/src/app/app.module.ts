import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from "@angular/common/http";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarsComponent } from './cars/cars.component';
import { CarFilterComponent } from './cars/car-filter/car-filter.component';
import { CarGridComponent } from './cars/car-grid/car-grid.component';
import { CarService } from './shared/car.service';

@NgModule({
  declarations: [
    AppComponent,
    CarsComponent,
    CarFilterComponent,
    CarGridComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [CarService],
  bootstrap: [AppComponent]
})
export class AppModule { }
