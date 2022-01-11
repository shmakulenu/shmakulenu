import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Patient } from '../Classes/patient';
import Swal from 'sweetalert2';

@Injectable({
  providedIn: 'root'
})
export class PatientsService {

  URL: String = "https://localhost:44319/api/Patients/";
  patients: Array<Patient>;
  
  constructor(private http: HttpClient) {
    this.patientsInit();
  }

  patientsInit() {
    this.GetAllPatient().subscribe
      (
        data => {
          this.patients = data;
        },
        err => {
          Swal.fire('',err.message,'error');
        }
      );
  }
  GetAllPatient(): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.URL + "GetAllPatient");
  }
  UpdatePatient(patient: Patient): Observable<boolean> {
    return this.http.put<boolean>(this.URL + "UpdatePatient", patient);
  }
  GetAllPatientByStatus(statusId: number): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.URL + "GetAllPatientByStatus/" + statusId);
  }
  GetPatientsByStatusAndSnif(snifId: number, statusId: number): Observable<Patient[]> {
    return this.http.get<Patient[]>(this.URL + "GetPatientsByStatusAndSnif/" + snifId + "/" + statusId);
  }
  GetPatientByTz(tz: number): Observable<Patient> {
    return this.http.get<Patient>(this.URL + "GetPatientsByTz/" + tz);
  }
  AddPatient(patient: Patient): Observable<boolean> {
    return this.http.post<boolean>(this.URL + "AddPatient", patient);
  }
  SendFormsMailToPatient(actions: Array<string>): Observable<boolean> {
    return this.http.post<boolean>(this.URL + "SendFormsMailToPatient", actions);
  }

  URL2: String = "https://localhost:44319/api/Tested/";
  AddTest(attachTest: Array<string>): Observable<boolean> {
    return this.http.post<boolean>(this.URL2 + "AddTest", attachTest);
  }
  AddFile(file): Observable<string> {
    return this.http.post<string>(this.URL2 + "AddFile", file);
  }
}
