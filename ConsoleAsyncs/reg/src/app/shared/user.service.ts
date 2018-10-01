import { Injectable } from '@angular/core';
import { Http, Response, Headers,RequestOptions,RequestMethod } from '@angular/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

import { User } from './user.model';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  selectedUser : User;
  constructor(private http: Http) { }
  postUser(user : User)
  {
    return this.http.post('http://localhost:64879/api/UserDetails',user);
    // var body=JSON.stringify(user);
    // var headerOptions= new Headers({'Content-Type':'application/json'});
    // var requestOptions= new RequestOptions({method :RequestMethod.Post, headers : headerOptions});
    // return this.http.post('url',body,requestOptions).map(x => x.json());
  }
}
