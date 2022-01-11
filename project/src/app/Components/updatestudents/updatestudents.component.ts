import { Component, OnInit } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { SpinerService } from '../../Services/spiner.service';
// import { setInterval } from 'timers';

@Component({
  selector: 'updatestudents',
  templateUrl: './updatestudents.component.html',
  styleUrls: ['./updatestudents.component.css']
})
export class UpdatestudentsComponent implements OnInit {

  loadingValue = 0;
  index: number = 0;
  actions: Array<string> = ['טעינת בדיקות שמיעה מטבלת ה Excel','פילוח אספים','פיענוח זכאויות','שליחת מיילים לעדכון הסניפים בתלמידים החדשים'];
  timer = null;

  constructor(private router: Router, private _snackBar: MatSnackBar) { }

  ngOnInit() {
    this.interval();
  }

  interval() {

    this.timer = setInterval(() => {
      this.loadingValue += 25;
      if(this.index < 4)
      {
        this._snackBar.open(this.actions[this.index], "", { duration: 1000})
        this.index++;
      }
      else
        this.router.navigate(["/menu/requestsTable"]);
    }, 1000)
  }

  routeBack() {
    this.router.navigate(["/menu/requestsTable"]);
  }

  ngOnDestroy(): void {
    this.index = 0;
    this.loadingValue = 0;
    clearInterval(this.timer);
  }

}
