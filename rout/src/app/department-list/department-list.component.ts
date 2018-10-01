import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-department-list',
  templateUrl:'./department-list.component.html',
  styleUrls:  ['./department-list.component.css']
})
export class DepartmentListComponent implements OnInit {

  departments= [ {"id" : 1 ,"name" :"Angular"},
  {"id" : 2 ,"name" :"Dotnet"} , 
  {"id" : 3 ,"name" :"Java"}, 
  {"id" : 4 ,"name" :"DW"},
  {"id" : 5 ,"name" :"SDET"}
]
  constructor(private router : Router) { }

  ngOnInit() {
  }
onselect(department)//navigating to new route.
{

  this.router.navigate(['/departments',department.id]);
}
}
