import { Component, OnInit } from '@angular/core';
import { EmployeeService } from "src/app/employees/shared/employee.service";
import { NgForm } from "@angular/forms";


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
        alert("success");
        this.employeeService.getEmployeeList();
    })
    
  }
}
  

  // else
  //  {
  //  this.employeeService.putEmployee(form.value.eid,form.value)
  //  .subscribe( data =>{
  //   this.resetForm(form);
  //   alert("updated");
  //   this.employeeService.getEmployeeList();

  //  });
  // }
    
  



