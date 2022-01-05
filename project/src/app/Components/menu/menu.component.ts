import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Location } from '@angular/common';
import { ReadexcelService } from '../../Services/readexcel.service';
import { SpinerService } from '../../Services/spiner.service';

@Component({
  selector: 'menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.css']
})
export class MenuComponent implements OnInit {

  constructor(private router:Router,private _location: Location,private excelService:ReadexcelService) { }

  ngOnInit() {
  }
  
  readAsapimFromExcel(){

    this.router.navigate(["/updatestudents"]);
    this.excelService.Get().subscribe(
      data=>{
        // alert(data);
      },
      err=>{
        // alert(err.massage);
      })
  }

  goToRequestTable(){
    this.router.navigate(["/requestsTable"]);

  }

  routeBack(){
    this.router.navigate(["/users"]);
  }
}
