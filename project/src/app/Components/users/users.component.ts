import { Component, OnInit, Input } from '@angular/core';
import { FormBuilder, FormGroup, FormControl, Validators, FormsModule, NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { UsersService } from '../../Services/users.service';

@Component({
  selector: 'users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(private fb: FormBuilder, private usersService: UsersService, private router: Router) {
  }

  ngOnInit() { }
  checkIfManager() {
    if (this.usersService.user.UserStatusName == "מנהל") {
      return true;
    }

  }

  GoToManager() {
    this.router.navigate(["/manager"]);
  }

  GoToMenu() {
    this.router.navigate(["/menu"]);
  }
  
  GoToUserTable() {
    this.router.navigate(["/userTable"]);
  }

}
