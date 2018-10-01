import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { EmpComponent } from './emp/emp.component';
import { EmployeeComponent } from './emp/employee/employee.component';
import { EmployeeListComponent } from './emp/employee-list/employee-list.component';
import {FormsModule} from '@angular/forms';
import {HttpModule} from '@angular/http';
//import { Observable } from 'rxjs';
import { CommonModule } from '@angular/common';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
 
import { ToastrModule } from 'ngx-toastr';
//import { HttpClientModule } from "@angular/common/http";
//import {HttpClient} from '@angular/common/http';

@NgModule({
  declarations: [
    AppComponent,
    EmpComponent,
    EmployeeComponent,
    EmployeeListComponent
   
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
   
    BrowserAnimationsModule, 
    ToastrModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
