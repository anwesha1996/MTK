import { Component,Input,Output,OnInit } from '@angular/core';
import{EmpserveService} from '../shared/empserve.service';
import {FormsModule} from '@angular/forms';
import { NgForm } from "@angular/forms";
@Component({
  selector: "app-employee",
  templateUrl: "./employee.component.html",
  styleUrls: ["./employee.component.css"]
})
export class EmployeeComponent implements OnInit {
  constructor(public employeeservices: EmpserveService) {}

  ngOnInit() {
    this.resetForm();
  }
  resetForm(form?: NgForm) {
    if(form!=null)
      
    form.reset();
    this.employeeservices.selectedEmployee = {
      EmpId: null,
      Firstname: "",
      Lastname: "",
      Empcode: "",
      Position: "",
      Office: ""
    };
  
  }
  onSubmit(form:NgForm) 
  {
 this.employeeservices.postEmployee(form.value).subscribe(data=>{this.resetForm(form);
})
  }
}
