import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Response } from "@angular/http";
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from './user.model';
import { HttpParams } from "@angular/common/http";

@Injectable()
export class UserService {

 selecteduser:User =new User();
 //namedetails:User
 user_name: any
 userlist : User[]
  constructor(private http: HttpClient) 
  {  }

  postUser(user: User)
   {
    return this.http.post('http://localhost:64879/api/UserDetails', user);
  }
//  getuser(name1:any)
//  {
   
//   return this.http.get('http://localhost:64879/api/UserDetails',name1).subscribe
//   ( (x: any) =>
//   this.user_name = x );
   
//  }
search(namedetails: User)
 {
  
  // const param = new HttpParams().set('name',name);
  //    // this.namedetails = namedetails;
  //     console.log(namedetails);
      return this.http.post('http://localhost:64879/api/search',namedetails);
    }
    showdata() {
      
        this.http.get('http://localhost:64879/api/Employees')
        .subscribe((x: User[]) =>
            this.userlist = x );
    }
 
}