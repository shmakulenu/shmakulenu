import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Snifim } from '../Classes/snifim';
@Injectable({
  providedIn: 'root'
})
export class SnifimService {
  URL:String="https://localhost:44319/api/Snifim/";

  constructor(private http:HttpClient) { }
  GetAllSnifim():Observable<Snifim[]>
  {
     return this.http.get<Snifim[]>(this.URL +"GetAllSnifim");   
  }
}
