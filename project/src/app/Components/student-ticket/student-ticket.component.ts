import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { PatientsService } from '../../Services/patients.service';
import { Patient } from '../../Classes/patient';
import { City } from '../../Classes/city';
import { Location } from '@angular/common';
import { CitiesService } from '../../Services/cities.service';
import { Snifim } from '../../Classes/snifim';
import { SnifimService } from '../../Services/snifim.service';
import { KupatCholim } from 'src/app/Classes/kupatCholim';
import { KupatcholimService } from 'src/app/Services/kupatcholim.service';
import { MatSnackBar } from '@angular/material';

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
  kupatCholim: Array<KupatCholim>;
  Tz: number;
  statusId: number;
  attachFile: Array<string>;
  filePath:string = "";
  isNew: boolean = true;

  constructor(private fb: FormBuilder, private route: ActivatedRoute,
    private patientSer: PatientsService, private _location: Location, private router: Router,
    private cityServies: CitiesService, private snifimService: SnifimService,
    private kupatCholimServies: KupatcholimService,private _snackBar: MatSnackBar) {
    this.route.paramMap.subscribe(p => {
      this.Tz = +p.get('Tz');
      this.statusId = +p.get('statusId');
      if (this.Tz)
        this.isNew = false;
      if (this.patientSer.patients == undefined) {
        this.getAllPatients();
      }
      this.initForm();
    })
  }

  ngOnInit() {
    
    this.getAllPatients();
    this.getAllCities();
    this.getAllSnifim();
    this.getAllKuputCholim();
  }

  getAllKuputCholim(){
    this.kupatCholimServies.GetAllKuputCholim().subscribe(
      data => {
        this.kupatCholim = data;
        console.log(this.kupatCholim);
      },
      err => {
        alert(err.message);
      }
    )
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
          // alert(err.message);
        }
      );
  }

  getAllCities() {
    this.cityServies.GetAllCities().subscribe(
      data => {
        this.cities = data;
      },
      err => {
        // alert(err.message);
      }
    )
  }

  getAllSnifim() {
    this.snifimService.GetAllSnifim().subscribe(
      data => {
        this.snifim = data;
      },
      err => {
        // alert(err.message);
      }
    )
  }

  routeBack() {
    if (this.statusId == 4)
      this.router.navigate(["/patientsTable/"]);
    else
      this.router.navigate(["/requestsTable/" + this.statusId]);
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
    if (!this.isNew)
      this.update();
    else if (this.isNew) {
      this.add();
      this.addTest(this.filePath);
    }

  }
  update() {
    if (this.detailsForm.valid) {
      this.patientSer.UpdatePatient(this.detailsForm.value).subscribe(
        data => {
          this.isSuccesfulUpdate = data;
          this._snackBar.open('העדכון נשמר בהצלחה!', "", { duration: 1000})
          // this.routeBack();
        },
        err => {
          // alert(err.message);
        }
      )
    }
    else {
      this.detailsForm.markAllAsTouched();
    }
  }

  add() {
    if (this.detailsForm.valid && this.filePath!="") {
      this.patientSer.AddPatient(this.detailsForm.value).subscribe(
        data => {
          this.isSuccesfulAdd = data;
        },
        err => {
          // alert(err.message);
        }
      )
    }
    else {
      this.detailsForm.markAllAsTouched();
    }
  }

  addTest(res: String) {
    this.attachFile = [this.detailsForm.value.Tz, res];
    if (this.detailsForm.valid) {
      this.patientSer.AddTest(this.attachFile).subscribe(
        data => {
          this.isSuccesfulAdd = data;
        },
        err => {
          // alert(err.message);
        }
      )
    }
    else {
      this.detailsForm.markAllAsTouched();
    }
  }

  initForm()
  {
  // this.age = 0;
    this.detailsForm = this.fb.group({
      SnifId: [null, Validators.required],
      KupatCholimid: [null, Validators.required],
      First_name: [null,[Validators.required ,Validators.minLength(2),Validators.maxLength(20)]],
      LastName: [null, [Validators.required ,Validators.minLength(2),Validators.maxLength(15)]],
      Tz: [null, [Validators.compose([Validators.required,Datevalid.is_israeli_id_number])]],
      date_of_birth: [null,[Validators.compose([Validators.required,Datevalid.passDate])]],
      CityId: [null, Validators.required],
      Address: [null, [Validators.required,Validators.maxLength(20),Validators.minLength(3)]],
      Age: [null],
      Class: [null],
      Intek_date: [null],
      RequestDate: [null],
      Tellephone1: [null,[ Validators.required ,Validators.pattern("[0-9 ]{9}")]],
      Mail: [null, Validators.email],
      // עבריות לחייב רק תבנית של אותיות
      //מקסימום נוסיף עוד פונקציה
      Father_Name: [null,[ Validators.required,Validators.minLength(3),Validators.maxLength(10)]],
      //need valid of tz
      FatherId: [null],
      Tellephone2: [null,[ Validators.required ,Validators.pattern("[0-9 ]{9}")]],
      //לחייב רק תבנית של אותיות
      Mother_Name: [null, [Validators.required,Validators.minLength(3),Validators.maxLength(10)]],
      MotherId: [null, Validators.required],
      Tellephone3: [null,[Validators.pattern("[0-9 ]{9}")]],
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
      RakezetMail: [null, Validators.email],
      Teacher: [null],
      EducationType: [null],
      Position: [null, Validators.required],
    })
    if (!this.isNew)
      this.getPatient();
  }

  get age(){

    return this.detailsForm.value.date_of_birth? new Date().getFullYear()-new Date(this.detailsForm.value.date_of_birth).getFullYear():null;
  }

  uploadFile(event: any) {
    if (event.target.files && event.target.files.length > 0) {
      let FileAsBase64 = ''
      const FileName = event.target.files[0].name

      // Use FileReader() object to get file to upload
      // NOTE: FileReader only works with newer browsers
      let reader = new FileReader();

      // Setup onload event for reader
      reader.onload = (e) => {

        // Store base64 encoded representation of file
        FileAsBase64 = reader.result.toString();

        // POST to server
   
        this.patientSer.AddFile({ FileAsBase64, FileName })
          .subscribe(res => { 
            this.filePath = res;
            // this.addTest(res);
           })
         
        // Read the file
      }
      reader.readAsDataURL(event.target.files[0]);

    }
  }

}
export class Datevalid{
  
  static passDate(fc: FormControl){
    //var d = new Date().getFullYear() כך מביאים את השנה העכשוית
    if(new Date(fc.value) > new Date())
      return( {passDate:true})
    else
      return null
  }
  static noPassDate(fc: FormControl){
    if(new Date(fc.value) < new Date())
      return( {noPassDate:true})
    else
      return null
  }
 
  static is_israeli_id_number(fc: FormControl) {
    let id = String(fc.value).trim();
    if (id.length > 9 || isNaN(Number(id))) return ({is_israeli_id_number:true});
    // id = id.length < 9 ? ("00000000" + id).slice(-9) : id;
    //   return ({is_israeli_id_number: Array.from(id, Number).reduce((counter, digit, i) => {
    //     const step = digit * ((i % 2) + 1);
    //     return counter + (step > 9 ? step - 9 : step);
    //   }) % 10 === 0})
  
  }
}
