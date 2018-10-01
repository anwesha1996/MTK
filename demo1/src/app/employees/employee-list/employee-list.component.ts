import { Component, OnInit } from '@angular/core';
import { EmployeeService } from "src/app/employees/shared/employee.service";

import {Employee} from 'd:/Angular/demo1/src/app/employees/shared/employee.model';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private employeeService:EmployeeService) { }

  ngOnInit() {
    this.employeeService.getEmployeeList();
  }

  edit(emp:Employee)
  {
    this.employeeService.selectedEmployee=Object.assign({},emp);
  }

}
