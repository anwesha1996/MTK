import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'd:/Angular/crud angular web api/angularCRUD/src/app/shared/employee.service';
import {NgForm} from '@angular/forms'
// import {Employee} from 'd:/Angular/crud angular web api/angularCRUD/src/app/shared/employee.model';

@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private employeeService:EmployeeService) { }

  ngOnInit() {
   this.resetForm();
  }
  resetForm(form? :NgForm)

  {
    if(form != null)
      form.reset();
      this.employeeService.selectedEmployee={
       eid:null,
       name: '',
       empcode: '',
       office:''
      }
  }
  onSubmit(form :NgForm)
  {
    this.employeeService.postEmployee(form.value)
    .subscribe( data =>{
      this.resetForm(form);
     
    })
}
}