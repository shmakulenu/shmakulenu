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
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material/dialog';
import { EmailsService } from '../../Services/emails.service';
import { MatSnackBar } from '@angular/material';
import { Datevalid } from '../student-ticket/student-ticket.component';
import { UsersService } from '../../Services/users.service';

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
    private klinaitsService: KlinaitsService, public dialog: MatDialog,private userService: UsersService ) {
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
      Date: [null, [Validators.compose([Validators.required,Datevalid.passDate])]],
      Intek_date: [null,Validators.required,],//, [Validators.compose([Validators.required,Datevalid.noPassDate])]
      Request__reaon: [null,[Validators.minLength(3)]],
      Summary: [null,[Validators.minLength(3)]],
      Talking1: [null],
      Talking1_date: [null],//[Validators.compose([Datevalid.passDate])]
      Talking2: [null],
      Talking2_date: [null],//,[Validators.compose([Datevalid.passDate])]
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
        if (data) {
          this.regiForm.patchValue(data);
          this.isNew = false;
        }
        else
          this.isNew = true;
      },
      err => {
        // alert(err.message);
      });
  }

  notes: string = "baruch hashem";

  getAllRequestStatus() {
    this.requestStatusService.GetAllRequestStatus().subscribe(
      data => {
        this.requestStatus = data;
      },
      err => {
        // alert(err.message);
      }
    )
  }
  getAllKlinaits() {
    this.klinaitsService.GetAllKlinaits().subscribe(
      data => {
        this.klinaits = data;
      },
      err => {
        // alert(err.message);
      }
    )
  }
  updateOrAddRequest() {

    this.requestService.tz=this.tz;
    if (!this.isNew) {
      // כדאי להכניס לפונקציה מסודרת
      if (this.regiForm.valid) {
        this.requestService.UpdateRequest(this.regiForm.value).subscribe(
          data => {
            this.isSuccesfulUpdate = data;
            this.getRequestByTz();
          },
          err => {
            if(this.userService.user == null)
              this.router.navigate(["/login"]);
            else
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
            this.getRequestByTz();
            if(this.userService.user == null)
              this.router.navigate(["/login"]);
            else
              this.router.navigate(["/menu"]);
          },
          err => {
            this.router.navigate(["/menu"]);
          }
        )
      }
      else {
        this.regiForm.markAllAsTouched();
      }
    }
  }

  getRequestByTz(){
    this.requestService.GetRequestByTz(this.tz).subscribe(
      data1 => {this.request = data1
      this.myDialog();
      if(this.userService.user == undefined)
        this.router.navigate(["/login"]);
      else
        this.router.navigate(["/menu"]);
      },
      err1 => {
        // alert(err1.message)
      })
  }

  myDialog() {
    if (this.request.StatusName == 'התקבל') {

      this.openDialog();
    }
  }
  openDialog(): void {
    const dialogRef = this.dialog.open(DialogComponent, {
      width: '300px',
      height:'300px',
    });

    dialogRef.afterClosed().subscribe(result => {  });
  }

  openCalender(){
    window.open("https://calendar.google.com/calendar/u/0/r?pli=1");
  }

}

//קומפוננטה לדילוג
@Component({
  selector: 'DialogComponent',
  templateUrl: './dialog.component.html',
})

export class DialogComponent {

  actions: Array<string> = ['שליחת לינק לקלינאית לפרוט פניית התלמיד','הצגת טופס זכאויות'];
  selected: String;
  isSuccess: boolean;
  implementations: Array<string>;

  constructor(private router: Router,  private requestService: RequestService, private emailsService: EmailsService,
    private _snackBar: MatSnackBar,
    public dialogRef: MatDialogRef<DialogComponent>){
  }

  submit(a:String) {
    this.implementations = [(this.requestService.tz).toString(), "http://localhost:4200/request/"+this.requestService.tz];
    if(a == "הצגת טופס זכאויות")
      this.router.navigate(["/credistimplementation/"+this.requestService.tz]);
    else if(a == "שליחת לינק לקלינאית לפרוט פניית התלמיד"){
      this.emailsService.SendMailToKlinaitAndPatient(this.implementations).subscribe(

           data=>{
             this.isSuccess = data;
             this._snackBar.open('המייל נשלח בהצלחה!', "", { duration: 1000})
           },
           err => {
            //  alert(err.message);
           }
         )
    }
    this.dialogRef.close(true);
  }

  onNoClick(): void {
    this.dialogRef.close();
  }

}
