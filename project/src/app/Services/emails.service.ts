import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class EmailsService {
  URL: string = "https://localhost:44319/api/Klinaits/";


  constructor(private http: HttpClient) { }

  SendMail(EAddressSend: string, ENameSend: string, EAddressGet: string, ENameGet: string) {
    return this.http.post<string>(`${this.URL}SendMail`,{EAddressSend,ENameSend,EAddressGet,ENameGet})
    .subscribe(x => console.log(x));
  }

  SendMailToKlinaitAndPatient(implementations: Array<string>):Observable<boolean>{
    return this.http.post<boolean>(this.URL+"SendMailToKlinaitAndPatient", implementations);
  }
  
}
