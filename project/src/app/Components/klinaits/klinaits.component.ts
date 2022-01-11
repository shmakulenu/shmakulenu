import { Route } from '@angular/compiler/src/core';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup,Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { RequestService } from 'src/app/Services/request.service';


@Component({
  selector: 'klinaits',
  templateUrl: './klinaits.component.html',
  styleUrls: ['./klinaits.component.css']
})
export class KlinaitsComponent implements OnInit {

  formData: FormGroup;
 
  constructor(private fb: FormBuilder, private router: Router, private requestService: RequestService) { }

  ngOnInit() {
    this.initForm();
  }

  initForm() {
    this.formData = this.fb.group({
      tz: [null, Validators.required]
    });
  }
  goToPatientRequest(){
    if (this.formData.valid) 
    {
      this.requestService.GetRequestByTz(this.formData.value.tz).subscribe(
        data => {
          if(data)
            this.router.navigate(["/request/" + this.formData.value.tz+"/1"]);
          else
          {
            this.formData.get('tz').setValue(null);
          }
        },
        err => {
          // alert(err.message);
        });
      
    }
    else
      this.formData.markAllAsTouched();
  }
}
