import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import {UserService } from '../shared/user.service';


@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css']
})
export class SearchComponent implements OnInit {

  constructor(private userService:UserService) { }

  ngOnInit() 
  {
  }

  show(form: NgForm) 
  {
   
   this.userService.search(form.value).subscribe(data=>{
 
     if(data)
       {
         alert("user record found");
        this.userService.showdata();
       }
       else
       {
         alert("user record not-found");
       }      
       
      });
}
}
