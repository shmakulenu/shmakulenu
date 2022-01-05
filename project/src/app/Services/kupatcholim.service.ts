import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { KupatCholim } from '../Classes/kupatCholim';



@Injectable({
  providedIn: 'root'
})
export class KupatcholimService {
  URL: String = "https://localhost:44319/api/KupatCholim/";
  
  constructor(private http: HttpClient) { }

  GetAllKuputCholim():Observable<KupatCholim[]>{
    return this.http.get<KupatCholim[]>(this.URL+"GetAllKuputCholim");
  }

}