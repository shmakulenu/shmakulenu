import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Request } from '../Classes/request';

@Injectable({
  providedIn: 'root'
})
export class RequestService {
  URL: String = "https://localhost:44319/api/Requests/";
  constructor(private http: HttpClient) { }
  GetAllRequest(): Observable<Request[]> {
    return this.http.get<Request[]>(this.URL + "GetAllRequest");
  }
  AddRequest(request: Request): Observable<boolean> {
    return this.http.post<boolean>(this.URL + "AddRequest", request);
  }
  GetRequestByTz(tz: number): Observable<Request> {
    return this.http.get<Request>(this.URL + "GetRequestByTz/" + tz);
  }
  UpdateRequest(request:Request):Observable<boolean>{
    return this.http.put<boolean>(this.URL+"UpdateRequest",request);
  }
}
