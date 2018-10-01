import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'd:/Angular/crud angular web api/angularCRUD/src/app/shared/employee.service';


@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],


})
export class EmployeesComponent implements OnInit {

  constructor(private employeeService:EmployeeService) { }

  ngOnInit() {
  }

}
