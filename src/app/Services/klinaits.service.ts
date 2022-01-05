import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Klinait } from '../Classes/klinait';



@Injectable({
  providedIn: 'root'
})
export class KlinaitsService {
  URL: String = "https://localhost:44319/api/Klinaits/";
  constructor(private http: HttpClient) { }

  GetAllKlinaits():Observable<Klinait[]>{
    return this.http.get<Klinait[]>(this.URL+"GetAllKlinaits");
  }

}
