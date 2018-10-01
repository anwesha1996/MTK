import { Component, OnInit } from '@angular/core';
import { EmployeeService } from 'd:/Angular/crud angular web api/angularCRUD/src/app/shared/employee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private employeeService:EmployeeService) { }

  ngOnInit() {
  }

}
