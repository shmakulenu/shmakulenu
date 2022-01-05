import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {Users} from '../Classes/users';
import {UserStatus} from '../Classes/userStatus';

@Injectable({
  providedIn: 'root'
})
export class UsersService {
  URL:String="https://localhost:44319/api/Users/";
  //ניסינו בדרך שנוכל לשתף מידע בין קומפוננטוצ אחים
   //users:Array<Users>;
  user:Users;
  
  constructor(private http:HttpClient) { }
  //
  GetAllUsers():Observable<Users[]>
  { 
     return this.http.get<Users[]>(this.URL +"GetAllUsers");   
  }
  GetUserByNameAndPassword(password:number,name:string):Observable<Users>
  {
    return this.http.get<Users>(this.URL +"GetUserByNameAndPassword/"+password+"/"+name);
  }
  AddUser(user:Users):Observable<boolean>
  {
    return this.http.post<boolean>(this.URL+"AddUser",user);
  }
  // פונקציה המחזירה את כל  סטטוס העובדים
  GetAllUsersStatus():Observable<UserStatus[]>
  {
      return this.http.get<UserStatus[]>(this.URL +"GetAllUsersStatus"); 
  }
}
