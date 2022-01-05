import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UsersComponent } from './Components/users/users.component';
import { ManagerComponent } from './Components/manager/manager.component';
import { MenuComponent } from './Components/menu/menu.component';
import { UsersTableComponent } from './Components/users-table/users-table.component';
import { PatientsTableComponent } from './Components/patients-table/patients-table.component';
import { RequestsTableComponent } from './Components/requests-table/requests-table.component';
import { LoginComponent } from './Components/login/login.component';
import { StudentTicketComponent } from './Components/student-ticket/student-ticket.component';
import { RequestComponent } from './Components/request/request.component';


const routes: Routes =
  [
    { path: "login", component: LoginComponent },
    { path: "users", component: UsersComponent },
    { path: "manager", component: ManagerComponent },
    { path: "student-ticket/:Tz", component: StudentTicketComponent },  
    { path: "menu", component: MenuComponent },  
    { path: "student-ticket", component: StudentTicketComponent }, 
    { path: "student-ticket/:Tz/:statusId", component: StudentTicketComponent }, 
    { path: "request/:tz", component: RequestComponent },   
    { path: "menu", component: MenuComponent,
      children:
        [
          { path: "patientsTable", component: PatientsTableComponent },
          { path: "requestsTable", component: RequestsTableComponent },
          { path: "requestsTable/:statusId", component: RequestsTableComponent },        
        ]
    },
    { path: "userTable", component: UsersTableComponent },     
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
