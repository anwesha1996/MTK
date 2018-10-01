import { Injectable } from '@angular/core';
import {Employee} from './employee.model';
import { map } from 'rxjs/operators';
import { Http, Response, Headers,RequestOptions,RequestMethod } from '@angular/http';
import { Observable } from 'rxjs';


 import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


  selectedEmployee:Employee;
  employeelist : Employee[];
  emp:Employee

  constructor(private http: HttpClient) { }

  postEmployee(emp : Employee)
  {
    return this.http.post('http://localhost:57078/api/Employees',emp);
  }
  getEmployeeList():Observable<Employee[]>
  {
   this.http.get('http://localhost:57078/api/Employees').pipe(map((data : Response) =>{
      return data as Employee[];
  })).subscribe(x => {

    this.employeelist = x;
  })
    
  }
  putEmployee(id,emp)
  {
    return this.http.post('http//localhost:57078/api/Employees/' + id,emp);
  }
}
