import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormsModule, NgForm } from '@angular/forms';
import { UsersService } from '../../Services/users.service';
import { Router } from '@angular/router';
import { Users } from '../../Classes/users';

@Component({
  selector: 'users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  // @Input("if-manager")
  // isManager:boolean;
  //isManager: boolean=true;
  //@Input("get-user")
  //user:Users;

  constructor(private fb: FormBuilder, private usersService: UsersService, private router: Router) {
  }

  ngOnInit() { }
  checkIfManager() {
    if (this.usersService.user.UserStatusName == "מנהל") {
      return true;
    }

  }
  //ניתוב לקומפוננטת מנהל
  GoToManager() {
    this.router.navigate(["/manager"]);
  }
  //ניתוב לקומפוננטת תפריט
  GoToMenu() {
    this.router.navigate(["/menu"]);
  }
  GoToUserTable() {
    this.router.navigate(["/userTable"]);
  }

}
