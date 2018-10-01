import { Component, OnInit } from '@angular/core';
import { User } from '../shared/user.model';
import { NgForm } from '@angular/forms';
import {UserService } from '../shared/user.service';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css'],
 
})
export class SignUpComponent implements OnInit {

  constructor(private userService:UserService) { }
 userList:User[]

  ngOnInit() {

  }
 
  OnSubmit(form : NgForm)
  {
 this.userService.postUser(form.value).subscribe((data)=>
  {
   if (data)
    {
    alert("Inserted");
    }

 })
  }
  // show(name1:any)
  // {
  //   this.userService.postUser(name1).subscribe(x=>
      
  //     {
  //       if(x)
  //         {
  //           alert("user found");
  //         }
  //         else
  //         {
  //           alert("not found");
  //         }
  //       });
        

  // }
}


