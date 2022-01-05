import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmailsService {
  URL: string = "https://localhost:44338/api/Emails/";

// צריך להפעיל פונקציה זו בלחיצה מסוימת על כפתור של שליחת מייל אבל צריך לשמור בדטה בייס 
// נתונים שצריך לשלוח לפונקציה כמו כתובת מייל ומלל וכו

  constructor(private http: HttpClient) { }

  SendMail(EAddressSend: string, ENameSend: string, EAddressGet: string, ENameGet: string) {
    return this.http.post<string>(`${this.URL}SendMail`,{EAddressSend,ENameSend,EAddressGet,ENameGet})
    .subscribe(x => console.log(x));
  }
}
