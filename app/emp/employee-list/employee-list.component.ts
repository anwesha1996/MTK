import { DisplayProcessor } from 'jasmine-spec-reporter/built/main';
import { Component, OnInit } from '@angular/core';
import{EmpserveService} from '../shared/empserve.service';
import { Employee} from '../shared/employee.model';
import {FormsModule} from '@angular/forms';
import { NgForm } from "@angular/forms";
import { ToastrService } from 'ngx-toastr';
@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private employeeservice:EmpserveService, private toast:ToastrService) { }

  ngOnInit() {
    this.employeeservice. getEmployee();
  }
Editdet(emp:Employee)
{
this.employeeservice.selectedEmployee=Object.assign({},emp);
}
Delete(id:string)
{
  if(confirm('Are you sure to delete data ?')==true){

  this.employeeservice.DeleteEmp(id).subscribe(x=>{
    this.employeeservice. getEmployee();
    this.toast.warning("Deleted Successfully");
  })
  }
 
}

}
