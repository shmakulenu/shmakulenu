import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { ActivatedRoute, Router } from '@angular/router';
import { EmailsService } from '../../Services/emails.service';
import { PatientsService } from '../../Services/patients.service';
import { SpinerService } from '../../Services/spiner.service';


@Component({
  selector: 'credistimplementation',
  templateUrl: './credistimplementation.component.html',
  styleUrls: ['./credistimplementation.component.css']
})
export class CredistimplementationComponent implements OnInit {

  tz: number;
  actions: Array<string>;
  isSuccess: boolean;
  constructor(private route: ActivatedRoute, private emailsService: EmailsService, private patientService: PatientsService
    ,private _snackBar: MatSnackBar, private router: Router,  private spinerService: SpinerService) {
    this.route.paramMap.subscribe(p => {
      this.tz = +p.get('tz');
    })
  }

  ngOnInit() {
  }

  sendToMail() {

    this.spinerService.showSpinner = true;

    //תיקיה משותפת של הקבצים
    const fileName = 'F:\\שנה ב\\angular\\Angular\\AngularMaterial\\פרויקט\\project\\src\\assets\\img\\IMG_1254.JPG'
    this.actions = [document.getElementById("myDiv").innerHTML, (this.tz).toString(), fileName];
    this.patientService.SendFormsMailToPatient(this.actions).subscribe(
      data => {
        this.spinerService.showSpinner = false;
        this._snackBar.open('המייל נשלח בהצלחה!', "", { duration: 1000})
      },
      err => {
        // alert(err.message);
      }
    )
  }
  
  print() {
    window.print();
  }

  routeBack() {
      this.router.navigate(["/menu/patientsTable/"]);
  }

}
