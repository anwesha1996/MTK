//import { HttpClient } from '@angular/common/http/public_api';
//import{Http,Response,Headers,RequestOptions,RequestMethod} from '@angular/http';
//import { map, switchMap, throttle } from 'rxjs/operators';
//import { Observable } from 'rxjs';
//import 'rxjs';
//import 'rxjs/add/operator/toPromise';
import {HttpClient} from '@angular/common/http';
import { Injectable } from '@angular/core';
import {Employee} from './employee.model';
import{Http,Response} from '@angular/http';
import { map} from 'rxjs/operators';




@Injectable({
  providedIn: 'root'
})
export class EmpserveService {

  selectedEmployee:Employee;
  constructor(private http:Http) { }

  postEmployee(emp:Employee)
  {
  //  var body=JSON.stringify(emp);
  //   var headeroptions = new Headers({'Content-Type':'application/json'});
  //   var requestoptions= new RequestOptions({method:RequestMethod.Post,headers:headeroptions});
/*const body:Employee={
    EmpId :emp.EmpId,
    Firstname :emp.Firstname,
    Lastname :emp.Lastname,
   Empcode :emp.Empcode,
   Position:emp.Position,
  Office:emp.Office
   }
   return this.http.post('http://localhost:52445/api/Employees',body);*/
   // return this.http.post('http://localhost:52445/api/Employees',body,requestoptions).pipe(map(x=>x.json()));
  return this.http.post('http://localhost:52445/api/Employees',emp);
  }
  putEmployee(id,emp)
  {
    // var body=JSON.stringify(emp);
    // var headeroptions = new Headers({'Content-Type':'application/json'});
    // var requestoptions= new RequestOptions({method:RequestMethod.Put,headers:headeroptions});
    // return this.http.put('http://localhost:52445/api/Employees/'+id,body,requestoptions).pipe(map(x=>x.json()));
   return this.http.put('http://localhost:52445/api/Employees/'+id,emp);
  }
  employeelist:Employee[];
 
  getEmployee()
  {
  //   this.http.get('http://localhost:52445/api/Employees')
  //   .pipe(map((data : Response)=>{
  //     return data.json() as Employee[];
  //   })).toPromise().then(x=>{
  //     this.employeelist=x;
  //  })
  // this.https.get('http://localhost:52445/api/Employees').subscribe((x:Employee[])=>{this.employeelist=x});
  return this.http.get('http://localhost:52445/api/Employees')
     .pipe(map((data : Response)=>{
     return data.json() as Employee[];
   })).subscribe(x=>{this.employeelist=x});
}
  DeleteEmp(id:string)
  {
//return this.http.delete('http://localhost:52445/api/Employees/'+id).pipe(map(x=>x.json()));
return this.http.delete('http://localhost:52445/api/Employees/'+id);
  }
}


