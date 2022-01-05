import { Injectable } from '@angular/core';
import { City } from '../Classes/city';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class CitiesService {

  URL: String = "https://localhost:44319/api/Cities/";
  cities: Array<City>;
  
  constructor(private http: HttpClient) { 
  }
  
  GetAllCities(): Observable<City[]> {
    return this.http.get<City[]>(this.URL + "GetAllCities");
  }
}
