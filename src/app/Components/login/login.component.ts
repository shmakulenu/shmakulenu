import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Users } from 'src/app/Classes/users';
import { UsersService } from 'src/app/Services/users.service';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  formData: FormGroup;
  // userName:string="";
  // password:number;
  //משתנה יוזר
  user: Users = null;
  //אם היוזר המתקבל ע"י קוד ושם הוא מנהל
  //isManager:boolean=false;
  constructor(private fb: FormBuilder, private usersService: UsersService, private router: Router) { }
  ngOnInit() {
    this.initForm();
  }
  initForm() {
    this.formData = this.fb.group({
      userName: ["", Validators.required],
      //יש להוסיף ולידציה לאיפשור מספרים בלבד????????????????????????????????????????
      password: [null, Validators.required]
    });
  }
  GetUserByNameAndPassword() {
    //let u=new Users(0,this.password,this.userName," ",0," ");
    if (this.formData.valid) {
      this.usersService.GetUserByNameAndPassword(this.formData.value.password, this.formData.value.userName).subscribe(
        data => {

          if (data == null) {
            this.formData.get('userName').setValue(null);
            this.formData.get('password').setValue(null);
          }
          else {
            this.usersService.user = data;
            this.router.navigate(["/users"]);
          }
        },
        err => { alert(err.message); }
      );
    }
    else
      this.formData.markAllAsTouched();
  }

}
