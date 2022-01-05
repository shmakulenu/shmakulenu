import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { RequestStatus } from '../Classes/request-status';

@Injectable({
  providedIn: 'root'
})
export class RequeststatusService {

  URL: String = "https://localhost:44319/api/RequestStatus/";
  
  constructor(private http: HttpClient) { }

  GetAllRequestStatus():Observable<RequestStatus[]>
  {
      return this.http.get<RequestStatus[]>(this.URL +"GetAllRequestStatus"); 
  }
}
