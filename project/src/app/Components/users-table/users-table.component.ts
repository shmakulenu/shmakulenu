import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../Services/users.service';
import { Users } from '../../Classes/users';
import { Location } from '@angular/common';
import { Sort } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'users-table',
  templateUrl: './users-table.component.html',
  styleUrls: ['./users-table.component.css']
})
export class UsersTableComponent implements OnInit {
 users:Array<Users>;
 displayedColumns: Array<string>;
 constructor(private usersService:UsersService,private _location: Location, private router: Router) { }

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
          this.displayedColumns = ["תעודת זהות",	"סיסמה",	"שם פרטי",	"שם משפחה",	"קוד סניף",	"סטטוס"];
       },
       err=>
       {
          alert(err.message);
       }
    );
  }

  onSelectUser(Tz: number){
    if (this.usersService.user.UserStatusName !== "מנהל") 
      alert("you are not a manager and dont have a permission to update and add user");
    else
      this.router.navigate(["/manager/" + Tz]);
  }

  routeBack() {
    this.router.navigate(["/menu"]);
  }

  sortData(sort: Sort) {
    const data = this.users.slice();
    if (!sort.active || sort.direction == '') {
      this.users = data;
      return;
    }
    this.users = data.sort((a, b) => {
      const isAsk = sort.direction == 'asc';
      switch (sort.active) {
        case 'תעודת זהות': return this.compare(a.User_tz, b.User_tz, isAsk);
        case 'סיסמה': return this.compare(a.Password, b.Password, isAsk);
        case 'שם פרטיר': return this.compare(a.User_name, b.User_name, isAsk);
        case 'שם משפחה': return this.compare(a.Last_name, b.Last_name, isAsk);
        case 'קוד סניף': return this.compare(a.SnifId, b.SnifId, isAsk);
        case 'קוד סטטוס': return this.compare(a.StatusId, b.StatusId, isAsk);
        case 'סטטוס': return this.compare(a.UserStatusName, b.UserStatusName, isAsk);
        default: return 0;
      }
    })

  }
  compare(a: number | string | Date, b: number | string | Date, isAsc: boolean) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }
}
