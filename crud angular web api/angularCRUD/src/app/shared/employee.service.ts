import { Injectable } from '@angular/core';
import {Employee} from './employee.model';
import { Http, Response, Headers,RequestOptions,RequestMethod } from '@angular/http';
import { Observable } from 'rxjs';


import { HttpClient } from "@angular/common/http";


@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  selectedEmployee:Employee;
  
  constructor(private http: HttpClient) { }
 
  postEmployee(employee : Employee)
  {
    return this.http.post('http://localhost:57078/api/Employees',employee);
  }
}
