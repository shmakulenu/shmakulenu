import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import {
  MatButtonModule,
  MatMenuModule,
  MatToolbarModule,
  MatIconModule,
  MatCardModule,
  MatFormFieldModule,
  MatInputModule,
  MatDatepickerModule,
  MatDatepicker,
  MatNativeDateModule,
  MatRadioModule,
  MatSelectModule,
  MatOptionModule,
  MatPaginatorModule,
  MatSortModule,
  MatGridListModule,
  MatSlideToggleModule,
  ErrorStateMatcher,
  ShowOnDirtyErrorStateMatcher,
  MatTableModule,
  MatProgressSpinnerModule,
  MatSnackBarModule,
  MatProgressBarModule
} from '@angular/material';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MyFormComponent } from './Components/my-form/my-form.component';
import { MyTableComponent } from './Components/my-table/my-table.component';
import { MyGridComponent } from './Components/my-grid/my-grid.component';
import { UsersComponent } from './Components/users/users.component';
import { HttpClientModule } from '@angular/common/http';
import { HomeComponent } from './Components/home/home.component';
import { ManagerComponent } from './Components/manager/manager.component';
import { RequestComponent, DialogComponent } from './Components/request/request.component';
import { StudentTicketComponent } from './Components/student-ticket/student-ticket.component';
import { PatientsTableComponent } from './Components/patients-table/patients-table.component';
import { UsersTableComponent } from './Components/users-table/users-table.component';
import { MenuComponent } from './Components/menu/menu.component';
import { RequestsTableComponent } from './Components/requests-table/requests-table.component';
import { LoginComponent } from './Components/login/login.component';
import { SearchpatientPipe } from './pipes/searchpatient.pipe';
import { CredistimplementationComponent } from './Components/credistimplementation/credistimplementation.component';
import { SearchuserPipe } from './Pipes/searchuser.pipe';
import { KlinaitsComponent } from './Components/klinaits/klinaits.component';
import { UpdatestudentsComponent } from './Components/updatestudents/updatestudents.component';
@NgModule({
  declarations: [
    AppComponent,
    MyFormComponent,
    MyTableComponent,
    MyGridComponent,
    UsersComponent,
    HomeComponent,
    ManagerComponent,
    RequestComponent,
    StudentTicketComponent,
    PatientsTableComponent,
    UsersTableComponent,
    MenuComponent,
    RequestsTableComponent,
    LoginComponent,
    SearchpatientPipe,
    DialogComponent,
    CredistimplementationComponent,
    SearchuserPipe,
    KlinaitsComponent,
    UpdatestudentsComponent,

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    MatButtonModule,
    MatMenuModule,
    MatToolbarModule,
    MatProgressBarModule,
    MatIconModule,
    MatCardModule,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDatepickerModule,
    MatNativeDateModule,
    MatRadioModule,
    MatSelectModule,
    MatOptionModule,
    MatSlideToggleModule,
    MatTableModule,
    MatPaginatorModule,
    MatSortModule,
    MatGridListModule,
    HttpClientModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
  ],
  entryComponents: [
    DialogComponent
  ],
  providers: [{ provide: ErrorStateMatcher, useClass: ShowOnDirtyErrorStateMatcher }],
  bootstrap: [AppComponent]
})
export class AppModule { }
