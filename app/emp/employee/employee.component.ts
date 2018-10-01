import { EmployeeListComponent } from './../employee-list/employee-list.component';
import { Component,Input,Output,OnInit } from '@angular/core';
import{EmpserveService} from '../shared/empserve.service';
import {FormsModule} from '@angular/forms';
import { NgForm } from "@angular/forms";
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: "app-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.css"]
})
export class EmployeeComponent implements OnInit {
  constructor(private employeeservices: EmpserveService, private toaster:ToastrService) {}
  
  ngOnInit() {
    this.resetForm();
   
  }
  resetForm(form?: NgForm) {
    if(form!=null)
      
    form.reset();
    this.employeeservices.selectedEmployee = {
      EmpId:null,
      Firstname: "",
      Lastname: "",
      Empcode: "",
      Position: "",
      Office: ""
    };
  
  }
  onSubmit(form:NgForm) 
  {
    if(form.value.EmpId==null)
    {
 this.employeeservices.postEmployee(form.value).subscribe(data=>{this.resetForm(form);
  this.employeeservices.getEmployee();
  this.toaster.success('New Record Added Sucessfully','Employee Register');
})
    }
    else
      {
//update
this.employeeservices.putEmployee(form.value.EmpId,form.value).subscribe(data=>{this.resetForm(form);
  this.employeeservices.getEmployee();
  this.toaster.success('Record Updated Successfully','Employee Register');
 

      })
  }
 
}
}
