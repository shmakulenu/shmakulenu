import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Users } from 'src/app/Classes/users';
import { UsersService } from 'src/app/Services/users.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { MatSnackBar } from '@angular/material';
import { SpinerService } from '../../Services/spiner.service';

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formData: FormGroup;
  klinaitPassword: number = 1234;
  user: Users = null;

  constructor(private fb: FormBuilder, private usersService: UsersService, private router: Router, private spinerService: SpinerService) { }
  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.formData = this.fb.group({
      userName: ["", Validators.required],
      password: [null, Validators.required]
    });
  }

  GetUserByNameAndPassword() {
    if (this.formData.value.password == this.klinaitPassword)
      this.router.navigate(["/klinaits"]);
    else if (this.formData.valid) {
    this.spinerService.showSpinner = true;
      this.usersService.GetUserByNameAndPassword(this.formData.value.password, this.formData.value.userName).subscribe(
        data => {
          this.spinerService.showSpinner = false;

          if (data == null) {
            this.formData.get('userName').setValue(null);
            this.formData.get('password').setValue(null);
          }
          else {
            this.usersService.user = data;
            this.router.navigate(["/users"]);
          }
        },
        err => { 
          // alert(err.message); 
        }
      );
    }
    else
      this.formData.markAllAsTouched();
  }

}

