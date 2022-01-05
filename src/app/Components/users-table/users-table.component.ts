import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../Services/users.service';
import { Users } from '../../Classes/users';
import { Location } from '@angular/common';

@Component({
  selector: 'users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {
 users:Array<Users>;
 displayedColumns: Array<string>;
 constructor(private usersService:UsersService,private _location: Location) { }

  ngOnInit() {
   this.GetAllUsers();
  }
  
  GetAllUsers()
  {
    this.usersService.GetAllUsers().subscribe
    (    
       data=>
       {
          this.users=data;
          this.displayedColumns = Object.keys(this.users[0]);
          //נסיון להעביר מידע בין קומפוננטות אחים       
          //this.usersService.users=data;
       },
       err=>
       {
          alert(err.message);
       }
    );
  }
    //חזור בדפדפן
    routeBack() {
      this._location.back();
    }

}
