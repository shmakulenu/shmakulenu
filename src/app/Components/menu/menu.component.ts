import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { ReadexcelService } from '../../Services/readexcel.service';

@Component({
  selector: 'menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private router:Router,private _location: Location,private excelService:ReadexcelService) { }

  ngOnInit() {
  }
  // GoToPatientsTable(){
  //     this.router.navigate(["/patientsTable"]);
  // }
  // GoToRequestsTable(){
  //   this.router.navigate(["/requestsTable"]);
  // }
  
  readAsapimFromExcel(){
    this.excelService.Get().subscribe(
      data=>{
        alert(data);
        console.log(data);
      },
      err=>{
        alert(err.massage);
      }
    )
  }
  //חזור בדפדפן
  routeBack(){
    this.router.navigate(["/users"]);
  }
}
