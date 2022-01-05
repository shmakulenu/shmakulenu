import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../Services/users.service';
import { Users } from '../../Classes/users';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Snifim } from '../../Classes/snifim';
import { SnifimService } from '../../Services/snifim.service';
import { UserStatus } from '../../Classes/userStatus';
import { Location } from '@angular/common';

@Component({
  selector: 'manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {
  //משתנים
  //אם הצליח הוספה
  isSuccesfulToAdd: boolean = false;
   regiForm: FormGroup;
  snifim: Array<Snifim>;
  userStatus: Array<UserStatus>;
  constructor(private usersService: UsersService, private fb: FormBuilder, private snifimService: SnifimService, private _location: Location) {
  }

  ngOnInit() {
    this.initForm();
    this.getAllSnifim();
    this.GetAllUsersStatus();
  }
  initForm() {
    this.regiForm = this.fb.group({
      User_tz: [null, Validators.required],
      User_name: [null, Validators.required],
      Last_name: [null, Validators.required],
      SnifId: [null, Validators.required],
      StatusId: [null, Validators.required],
      Password: [null, Validators.required],
    })
  }
  getAllSnifim() {
    this.snifimService.GetAllSnifim().subscribe(
      data => {
        this.snifim = data;
      },
      err => {
        alert(err.message);
      }
    );
  }
  GetAllUsersStatus() {
    this.usersService.GetAllUsersStatus().subscribe
      (
      data => {
        this.userStatus = data;
      },
      err => {
        alert(err.message);
      }
      );
  }
  AddUser() {
    //let newUser=new Users(this.regiForm.value); 
    //let newUser=new Users(this.regiForm.value.User_tz,this.regiForm.value.Password,this.regiForm.value.User_name,this.regiForm.value.Last_name,this.regiForm.value.SnifId,this.regiForm.value.StatusId,"");
    if(this.regiForm.valid)
    {
    this.usersService.AddUser(this.regiForm.value).subscribe(
      data => {
        this.isSuccesfulToAdd = data;
        alert(data);
      },
      err => { alert(err.message); }
    )
  }
  else
  this.regiForm.markAllAsTouched();
  }
  //חזור בדפדפן
  routeBack() {
    this._location.back();
  }
}
