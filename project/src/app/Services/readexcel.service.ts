import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Asapim } from '../Classes/asapim';

@Injectable({
  providedIn: 'root'
})
export class ReadexcelService {

  URL: String = "https://localhost:44319/api/ReadExcel/";

  constructor(private http: HttpClient) { }
  
  Get(): Observable<Asapim[]> {
    return this.http.get<Asapim[]>(this.URL + "Get");
  }
}
