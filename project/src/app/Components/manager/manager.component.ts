import { Component, OnInit } from '@angular/core';
import { UsersService } from '../../Services/users.service';
import { Users } from '../../Classes/users';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Snifim } from '../../Classes/snifim';
import { SnifimService } from '../../Services/snifim.service';
import { UserStatus } from '../../Classes/userStatus';
import { Location } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'manager',
  templateUrl: './manager.component.html',
  styleUrls: ['./manager.component.css']
})
export class ManagerComponent implements OnInit {

  isSuccesfulUpdate: boolean = false;
  isSuccesfulToAdd: boolean = false;
  regiForm: FormGroup;
  snifim: Array<Snifim>;
  userStatus: Array<UserStatus>;
  Tz: number;
  isNew: boolean = true;
  user: Users;

  constructor(private usersService: UsersService, private fb: FormBuilder, private snifimService: SnifimService, private _location: Location
    , private route: ActivatedRoute, private router:Router,private _snackBar: MatSnackBar) {
    this.route.paramMap.subscribe(u => {
      this.Tz = +u.get('Tz');
      if(this.Tz)
        this.isNew = false;
      else if(this.usersService.users == undefined) 
        this.getAllUsers();
      this.initForm();
    })
  }

  ngOnInit() {
    this.getAllUsers();
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

    if (!this.isNew)
      this.getUser();
  }

  getUser(){
    this.user = this.usersService.users.find(u => u.User_tz == this.Tz);
    this.regiForm.patchValue(this.user);
  }

  getAllUsers() {
    this.usersService.GetAllUsers().subscribe
      (
        data => {
          this.usersService.users = data;
        },
        err => {
          // alert(err.message);
        }
      );
  }

  getAllSnifim() {
    this.snifimService.GetAllSnifim().subscribe(
      data => {
        this.snifim = data;
      },
      err => {
        // alert(err.message);
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
        // alert(err.message);
      }
      );
  }

  AddOrUpdateUser() {
   if(this.isNew)
    this.Add();
  else if(!this.isNew)
    this.update();
  }

  update(){
    if (this.regiForm.valid) {
      this.usersService.UpdateUser(this.regiForm.value).subscribe(
        data => {
          this.isSuccesfulUpdate = data;
          this._snackBar.open('עדכון העובד נשמר בהצלחה!', "", { duration: 2000})
          this.router.navigate(["/userTable"]);
        },
        err => {
          // alert(err.message);
        }
      )
    }
    else {
      this.regiForm.markAllAsTouched();
    }
  }

  Add(){
    if(this.regiForm.valid)
    {
      this.usersService.AddUser(this.regiForm.value).subscribe(
        data => {
          this.isSuccesfulToAdd = data;
          this._snackBar.open('העובד נשמר בהצלחה!', "", { duration: 2000})
          this.router.navigate(["/users"]);
        },
        err => {
           alert(err.message); 
          } )
    }
    else
      this.regiForm.markAllAsTouched();
  }
  
  routeBack() {
    this.router.navigate(["/users"]);
    
    // this._location.back();
  }
 
}
