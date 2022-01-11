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
import { CredistimplementationComponent } from './Components/credistimplementation/credistimplementation.component';
import { KlinaitsComponent } from './Components/klinaits/klinaits.component';
import { UpdatestudentsComponent } from './Components/updatestudents/updatestudents.component';

const routes: Routes =
  [
    { path: "login", component: LoginComponent },
    // { path: "users", component: UsersComponent },
    { path: "manager", component: ManagerComponent },
    { path: "manager/:Tz", component: ManagerComponent },
    { path: "student-ticket/:Tz", component: StudentTicketComponent }, 
    { path: "userTable", component: UsersTableComponent },  
    { path: "menu", component: MenuComponent },  
    { path: "student-ticket", component: StudentTicketComponent }, 
    { path: "credistimplementation/:tz", component: CredistimplementationComponent },
    { path: "klinaits", component: KlinaitsComponent }, 
    { path: "credistimplementation", component: CredistimplementationComponent },  
    { path: "updatestudents", component: UpdatestudentsComponent },  
    { path: "requestsTable", component: RequestsTableComponent },
    { path: "patientsTable", component: PatientsTableComponent },
    { path: "userTable", component: UsersTableComponent }, 
    { path: "request/:tz/:klinait", component: RequestComponent },   
    { path: "menu", component: MenuComponent,
    
      children:
        [
          
          { path: "patientsTable", component: PatientsTableComponent },
          { path: "requestsTable", component: RequestsTableComponent },
          { path: "requestsTable/:statusId", component: RequestsTableComponent },  
          { path: "manager", component: ManagerComponent },
    { path: "manager/:Tz", component: ManagerComponent },
    { path: "updatestudents", component: UpdatestudentsComponent },  
    { path: "userTable", component: UsersTableComponent }, 
    { path: "student-ticket", component: StudentTicketComponent }, 
    { path: "student-ticket/:Tz/:statusId", component: StudentTicketComponent }, 
    { path: "request/:tz/:klinait", component: RequestComponent },   
    {
      path: '',
      outlet: 'requestsTable/1',
      component: RequestsTableComponent,
    },
    {
      path: '',
      redirectTo:'requestsTable', pathMatch: 'full'
    }
        ]
    },
       
  ];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
