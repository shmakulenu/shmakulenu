import { Component, OnInit, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { RequestService } from '../../Services/request.service';
import { Request } from '../../Classes/request';
import { Router, ActivatedRoute } from '@angular/router';
import { PatientsService } from '../../Services/patients.service';
import { Patient } from '../../Classes/patient';
import { RequestStatus } from '../../Classes/request-status';
import { RequeststatusService } from '../../Services/requeststatus.service';
import { Klinait } from '../../Classes/klinait';
import { KlinaitsService } from '../../Services/klinaits.service';
import { MatDialog, MatDialogRef, MAT_DIALOG_DATA } from '@angular/material';

@Component({
  selector: 'request',
  templateUrl: './request.component.html',
  styleUrls: ['./request.component.css']
})
export class RequestComponent implements OnInit {

  isSuccesfulUpdate: boolean = false;
  isSuccesfulAdd: boolean = false;
  regiForm: FormGroup;
  tz: number;
  patient: Patient;
  request: Request;
  requestStatus: Array<RequestStatus>;
  klinaits: Klinait[];
  isNew: boolean = true;
  constructor(private fb: FormBuilder, private patientsService: PatientsService, private requestService: RequestService,
    private router: Router, private route: ActivatedRoute, private requestStatusService: RequeststatusService,
    private klinaitsService: KlinaitsService, public dialog: MatDialog, ) {
    this.route.paramMap.subscribe(p => {
      this.tz = +p.get('tz');
      this.initForm();
    })
  }

  ngOnInit() {
    this.getAllRequestStatus();
    this.getAllKlinaits();
  }

  initForm() {
    this.regiForm = this.fb.group({
      Patient_tz: [null],
      Date: [null, Validators.required],
      Intek_date: [null, Validators.required],
      Request__reaon: [null],
      Summary: [null],
      Talking1: [null],
      Talking1_date: [null],
      Talking2: [null],
      Talking2_date: [null],
      NumKlinait: [null],
      // קונטרול זה הוא שם הקלינאית
      Name: [null],
      notes: [null],
      StatusId: [null],
      StatusName: [{ disabled: true, value: null }, Validators.required],
    })
    this.initRequestByTz();
  }

  initRequestByTz() {
    this.requestService.GetRequestByTz(this.tz).subscribe(
      data => {
        this.request = data;
        console.log(this.request);
        if (data) {
          this.regiForm.patchValue(data);
          this.isNew = false;
        }
        else
          this.isNew = true;
      },
      err => {
        alert(err.message);
      });
  }
  //משתנים אלו אמורים להיות שאובים מכרטיס תלמיד

  notes: string = "baruch hashem";

  getAllRequestStatus() {
    this.requestStatusService.GetAllRequestStatus().subscribe(
      data => {
        this.requestStatus = data;
        console.log(this.requestStatus);
      },
      err => {
        alert(err.message);
      }
    )
  }
  getAllKlinaits() {
    this.klinaitsService.GetAllKlinaits().subscribe(
      data => {
        this.klinaits = data;
      },
      err => {
        alert(err.message);
      }
    )
  }
  updateOrAddRequest() {
    if (!this.isNew) {
      // כדאי להכניס לפונקציה מסודרת
      if (this.regiForm.valid) {
        this.requestService.UpdateRequest(this.regiForm.value).subscribe(
          data => {
            this.isSuccesfulUpdate = data;
            alert(data);
            this.myDialog();
            // בעקרון צריך לחזור לטבלה ממנה הגיע או מפציינטים או מפניות
            this.router.navigate(["/menu"]);
          },
          err => {
            alert(err.message);
            // בעקרון צריך לחזור לטבלה ממנה הגיע או מפציינטים או מפניות
            this.router.navigate(["/menu"]);
          }
        )
      }
      else {
        this.regiForm.markAllAsTouched();
      }
    }
    else if (this.isNew) {
      // כדאי להכניס לפונקציה מסודרת
      if (this.regiForm.valid) {
        this.requestService.AddRequest(this.regiForm.value).subscribe(
          data => {
            this.isSuccesfulAdd = data;
            alert(data);
            this.myDialog();
            // בעקרון צריך לחזור לטבלה ממנה הגיע או מפציינטים או מפניות
            this.router.navigate(["/menu"]);
          },
          err => {
            alert(err.message);
            // בעקרון צריך לחזור לטבלה ממנה הגיע או מפציינטים או מפניות
            this.router.navigate(["/menu"]);
          }
        )
      }
      else {
        this.regiForm.markAllAsTouched();
      }
    }
  }

  myDialog() {

    if (this.request.StatusName == 'התקבל') {

      this.openDialog();
    }
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '250px',
      // data: { actions: data},
    });

    dialogRef.afterClosed().subscribe(result => {    
      if (result)
        this.router.navigate(["/menu"]);
      else
      // כאן יתבצע מעבר לקומפוננטה עם כפתורים שכל כפתור מבצע פעולה אחרת 
        this.router.navigate(["/menu"]);
    });
  }

  // updateStatus(statusId: number) {
  //   this.regiForm.value.statusId = statusId;
  //   if (this.regiForm.valid)
  //     this.router.navigate(["/student-ticket/" + this.tz]);
  //   else
  //     this.regiForm.markAllAsTouched();
  // }
}

//קומפוננטה לדילוג
@Component({
  selector: 'dialog',
  templateUrl: 'dialog.component.html',
})
export class DialogComponent {

  // actions: Array<string> = ['שליחת לינק לקלינאית לכרטיס תלמיד','הצגת טופס זכאויות'];
  selected: number;

  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    // @Inject(MAT_DIALOG_DATA) public data: any
  ) {
    // this.actions = data.actions;

  }
  submit() {
    this.dialogRef.close(true);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
