import { Component, OnInit } from '@angular/core';
import { Patient } from '../../Classes/patient';
import { PatientsService } from '../../Services/patients.service';
import { Router } from '@angular/router';
import { UsersService } from '../../Services/users.service';
import { Sort } from '@angular/material';

@Component({
  selector: 'patients-table',
  templateUrl: './patients-table.component.html',
  styleUrls: ['./patients-table.component.css']
})
export class PatientsTableComponent implements OnInit {
  patients: Array<Patient>;
  //מערך המכיל את כותרות הטבלה
  displayedColumns: Array<string> = [' תאריך-איינטיק ', ' קופ"ח ', ' עיר ', ' כתובת ', ' טלפון- 2 ', ' טלפון- 1 ', ' מין ', 'שם-משפחה', ' שם-פרטי ', ' תאריך-לידה ', ' תעודת-זהות ','פעולות'];
  constructor(private patientService: PatientsService, private router: Router, private userService: UsersService) { }

  ngOnInit() {
    this.initTable();
  }

  //מקשיב לשינויים ובכל שינוי של המערך זה מתעדכן פה
  //מתנהגים איתו כמו עם משתנה
  //לא למחוק הערה זו
  // get patients(): Array<Patient> {
  //   return this.patientService.patients;
  // }

  initTable() {
    if (this.userService.user.UserStatusName == "מנהל") {
      this.patientService.GetAllPatientByStatus(4).subscribe(
        data => {
          this.patients = data;
        },
        err => {
          // alert(err.Message);
        })
    }
    else {
      this.patientService.GetPatientsByStatusAndSnif(this.userService.user.SnifId, 4).subscribe(
        data => {
          this.patients = data;
        },
        err => {
          // alert(err.Message);
        })
    }
  }

  onSelectPatient(Tz: number, statusId: number) {
    this.router.navigate(["/menu/student-ticket/" + Tz + "/" + statusId]);
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
        case ' תאריך-איינטיק ': return this.compare(a.Intek_date, b.Intek_date, isAsk);
        case ' קופ"ח ': return this.compare(a.KupatCholimName, b.KupatCholimName, isAsk);
        case ' עיר ': return this.compare(a.CityName, b.CityName, isAsk);
        case ' כתובת ': return this.compare(a.Address, b.Address, isAsk);
        case ' טלפון- 2 ': return this.compare(a.Tellephone2, b.Tellephone2, isAsk);
        case ' טלפון- 1 ': return this.compare(a.Tellephone1, b.Tellephone1, isAsk);
        case ' מין ': return this.compare(a.Min, b.Min, isAsk);
        case 'שם-משפחה': return this.compare(a.LastName, b.LastName, isAsk);
        case ' שם-פרטי ': return this.compare(a.First_name, b.First_name, isAsk);
        case ' תאריך-לידה ': return this.compare(a.date_of_birth, b.date_of_birth, isAsk);
        case ' תעודת-זהות ': return this.compare(a.Tz, b.Tz, isAsk);
        default: return 0;
      }
    })

  }
  compare(a: number | string | Date, b: number | string | Date, isAsc: boolean) {
    return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
  }
}
