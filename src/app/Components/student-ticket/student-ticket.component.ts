import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientsService } from '../../Services/patients.service';
import { Patient } from '../../Classes/patient';
import { City } from '../../Classes/city';
import { Location } from '@angular/common';
import { CitiesService } from '../../Services/cities.service';
import { Snifim } from '../../Classes/snifim';
import { SnifimService } from '../../Services/snifim.service';

@Component({
  selector: 'student-ticket',
  templateUrl: './student-ticket.component.html',
  styleUrls: ['./student-ticket.component.css']
})
export class StudentTicketComponent implements OnInit {
  isSuccesfulUpdate: boolean = false;
  isSuccesfulAdd: boolean = false;
  detailsForm: FormGroup;
  educationForm: FormGroup;
  frameTypes: Array<string> = ['גן', 'מעון', 'בי"ס', 'תיכון', 'ישיבה'];
  positions: Array<string> = ['מוכש"ר', 'פטור', 'תרבותי יחודי', 'ממח'];
  educationTypes: Array<string> = ['גן חנו"מ', 'גן שפה', 'רגיל', 'גן לקו"ש', 'כיתה מקדמת', 'בי"ס חנו"מ'];
  cities: Array<City>;
  snifim: Array<Snifim>;
  patient: Patient;
  Tz: number;
  statusId: number;
  // משתנה בוליאני המסמל האם יוצרים תלמיד חדש או שמציגים את נתוניו בכרטיס תלמיד
  isNew: boolean = true;

  constructor(private fb: FormBuilder, private route: ActivatedRoute,
    private patientSer: PatientsService, private _location: Location, private router: Router,
    private cityServies: CitiesService, private snifimService: SnifimService) {
    this.route.paramMap.subscribe(p => {
      this.Tz = +p.get('Tz');
      this.statusId = +p.get('statusId');
      // רק מעדכנים ולא יוצרים חדש
      if (this.Tz)
        this.isNew = false;
      if (this.patientSer.patients == undefined) {
        this.getAllPatients();
      }     
      this.initForm();    
    })
    // this.route.paramMap.subscribe(p => {
    //   alert(+p.get('patient'));
    //איך ממירים את מה שחוזר לפציינט ולא למספר 
    //ע"י הפלוס המרנו למספר
    //   this.patient = p.get('patient');    
    //   if (this.patientSer.patients == undefined) {      
    //     this.getAllPatients();      
    //   }
    //   else {      
    //     this.getPatient();        
    //   }
    // })
  }

  ngOnInit() {
    this.getAllPatients();
    this.getAllCities();
    this.getAllSnifim();
  }

  getPatient() {
    this.patient = this.patientSer.patients.find(p => p.Tz == this.Tz);
    this.detailsForm.patchValue(this.patient);
  }
  getAllPatients() {
    this.patientSer.GetAllPatient().subscribe
      (
      data => {
        this.patientSer.patients = data;
      },
      err => {
        alert(err.message);
      }
      );
  }
  getAllCities() {
    this.cityServies.GetAllCities().subscribe(
      data => {
        this.cities = data;
        console.log(this.cities);
      },
      err => {
        alert(err.message);
      }
    )
  }
  getAllSnifim() {
    this.snifimService.GetAllSnifim().subscribe(
      data => {
        this.snifim = data;
        console.log(this.cities);
      },
      err => {
        alert(err.message);
      }
    )
  }
  routeBack() {
    // אם הגענו עם סטטוס התקבל 4 נחזור לטבלת פציינטים
    if (this.statusId == 4) 
      this.router.navigate(["/menu/patientsTable/"]);
    else
      // if (this.statusId == 1 || this.statusId == 2|| this.statusId == 3) <--- כלומר
      this.router.navigate(["/menu/requestsTable/" + this.statusId]);
  }

  goToRequest(tz) {
    if (this.detailsForm.valid) {
      this.updateOrAddPatient();
      this.router.navigate(["/request/" + tz]);
    }
    else
      this.detailsForm.markAllAsTouched();
  }

  updateOrAddPatient() {
    // רציתי להוסיף את זה לתנאי ואז הקומפוננטה לא תעבור לקומפוננטת 
    // request
    // כי התעודת זהות לא תקינה
    // ואז ניתן להוריד את ה
    // disabled
    // מכפתור המעבר לעדכון סטטוס
    // && this.detailsForm.value.Tz==0
    if (!this.isNew)
      this.update();
    else if (this.isNew)
      this.add();
  }
  update() {
    if (this.detailsForm.valid) {
      this.patientSer.UpdatePatient(this.detailsForm.value).subscribe(
        data => {
          this.isSuccesfulUpdate = data;
          alert(data);
        },
        err => {
          alert(err.message);
        }
      )
    }
    else {
      this.detailsForm.markAllAsTouched();
    }
  }
  add() {
    if (this.detailsForm.valid) {
      this.patientSer.AddPatient(this.detailsForm.value).subscribe(
        data => {
          this.isSuccesfulAdd = data;
          alert(data);
        },
        err => {
          alert(err.message);
        }
      )
    }
    else {
      this.detailsForm.markAllAsTouched();
    }
  }
  initForm()
  //לבדוק איזה מהשדות יכולות להיות
  //null
  //ואיזה לא
  {
    this.detailsForm = this.fb.group({
      SnifId: [null, Validators.required],
      First_name: [null, Validators.required],
      LastName: [null, Validators.required],
      Tz: [null, Validators.required],
      date_of_birth: [null],
      CityId: [null, Validators.required],
      Address: [null, Validators.required],
      Age: [null],
      Class: [null],
      Intek_date: [null],
      RequestDate: [null],
      Tellephone1: [null, Validators.required],
      Mail: [null,Validators.email],
      Father_Name: [null, Validators.required],
      FatherId: [null],
      Tellephone2: [null, Validators.required],
      Mother_Name: [null, Validators.required],
      MotherId: [null, Validators.required],
      Tellephone3: [null],
    })
    this.educationForm = this.fb.group({
      FrameType: [null, Validators.required],
      School: [null, Validators.required],
      Semel: [null],
      Tellephone: [null],
      City: [null],
      Address: [null],
      Rakezet_shiluv: [null],
      RakezetTellephone: [null],
      RakezetMail: [null,Validators.email],
      Teacher: [null],
      EducationType: [null],
      Position: [null, Validators.required],
    })
    if (!this.isNew)
      this.getPatient();
  }

}
