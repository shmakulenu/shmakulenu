import { Component, OnInit, OnDestroy } from '@angular/core';
import { RequestService } from '../../Services/request.service';
import { PatientsService } from '../../Services/patients.service';
import { Patient } from '../../Classes/patient';
import { Router, ActivatedRoute } from '@angular/router';
import { UsersService } from '../../Services/users.service';
import { Sort } from '@angular/material';

@Component({
  selector: 'requests-table',
  templateUrl: './requests-table.component.html',
  styleUrls: ['./requests-table.component.css']
})
export class RequestsTableComponent implements OnInit, OnDestroy {

  patients: Array<Patient>;
  isShow: boolean = false;
  requestByStatusId: Array<Patient> = new Array<Patient>();
  displayedColumns: Array<string>;
  statusId: number;
  toogle1: boolean;
  toogle2: boolean;
  toogle3: boolean;
  klinait = 0;
  constructor(private requestService: RequestService, private patientsService: PatientsService,
    private router: Router, private usersService: UsersService, private route: ActivatedRoute) {
    this.route.paramMap.subscribe(p => {
      this.statusId = +p.get('statusId');
      this.klinait = +p.get('klinait');
      if (this.statusId) {
        this.showTable(this.statusId);
      }
    })
  }

  ngOnInit() {
  }
  
  showTable(statusId: number) {
    if (statusId == 1) {
      this.toogle1 = true;
      this.toogle2 = false;
      this.toogle3 = false;
    }
    else if (statusId == 2) {
      this.toogle1 = false;
      this.toogle2 = true;
      this.toogle3 = false;
    }
    else if (statusId == 4) {
      this.toogle1 = false;
      this.toogle2 = false;
      this.toogle3 = true;
    }
  //  this.displayedColumns = ['הערות', 'קופ"ח', 'עיר', 'כתובת', 'טל נייד', 'טלפון', 'תאריך לידה', 'תעודת זהות', 'שם', 'תאריך הפניה'];
    // this.displayedColumns = [
    //   'הערות'

    // , 'קופ"ח'
    // , 'עיר'
    // , 'כתובת', 
    // 'טל נייד',
    //  'טלפון'
    // , 'תאריך לידה',
    //  'תעודת זהות'
    //  , 'שם',
    //  'תאריך הפניה'];
     this.displayedColumns = ['תאריך הפניה','שם','תעודת זהות','תאריך לידה','טלפון',
 'טל נייד', 'כתובת', 'עיר' , 'קופ"ח','הערות','פעולות'

     ];
    this.isShow = true;
    if (this.usersService.user.UserStatusName == "מנהל") {
      this.patientsService.GetAllPatientByStatus(statusId).subscribe(
        data => {
          this.patients = data;
        },
        err => {
          // alert(err.Message);
        })
    }
    else {
      this.patientsService.GetPatientsByStatusAndSnif(this.usersService.user.SnifId, statusId).subscribe(
        data => {
          this.patients = data;
        },
        err => {
          // alert(err.Message);
        })
    }
  }

  // showPatsientsTable(){
    // this.router.navigate(["/patientsTable"]);
  // }

  onSelectRequest(tz, statusId) {
    if(this.klinait == 0)
    {
      this.router.navigate(["/menu/student-ticket/" + tz + "/" + statusId]);

    }
    else{
    this.router.navigate(["/student-ticket/" + tz + "/" + statusId]);
  }}

  goToEmptyStudentTicket() {
    if(this.klinait == 0)
    { this.router.navigate(["/menu/student-ticket"]);}
    else{
    this.router.navigate(["/student-ticket" ]);
  }
  }
  routeBack(){
    this.router.navigate(["/menu"]);
  }


  // מיון הטבלה לפי הכותרות
  sortData(sort: Sort) {
    const data = this.patients.slice();
    if (!sort.active || sort.direction == '') {
      this.patients = data;
      return;
    }

    this.patients = data.sort((a, b) => {
      const isAsk = sort.direction == 'asc';
      switch (sort.active) {
        case 'תאריך הפניה': return this.compare(a.RequestDate, b.RequestDate, isAsk);
        case 'קופ"ח': return this.compare(a.KupatCholimName, b.KupatCholimName, isAsk);
        case 'עיר': return this.compare(a.CityName, b.CityName, isAsk);
        case 'כתובת': return this.compare(a.Address, b.Address, isAsk);
        case 'טלפון': return this.compare(a.Tellephone2, b.Tellephone2, isAsk);
        case 'טל נייד': return this.compare(a.Tellephone1, b.Tellephone1, isAsk);
        case 'מוסד': return this.compare(a.School, b.School, isAsk);
        case 'שם' : return this.compare(a.First_name, b.First_name, isAsk);
        case 'תאריך לידה': return this.compare(a.date_of_birth, b.date_of_birth, isAsk);
        case 'תעודת זהות': return this.compare(a.Tz, b.Tz, isAsk);
        case 'הערות':return this.compare(a.Notes,b.Notes,isAsk);
        default: return 0;
      }
    })

  }
  compare(a: number | string | Date, b: number | string | Date, isAsc: boolean) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }

  ngOnDestroy(): void {
    // פונקציה זו קוראת שניה לפני שהקומפוננטה מתה
  }
}
