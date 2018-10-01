import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-test',
  templateUrl: './testcomponent.component.html',
  styleUrls: ['./testcomponent.component.css']
})
export class TestcomponentComponent implements OnInit {

pageTitle:string="Data binding in angular";
imageUrl:string="assets/header.jpg";
imageUrl1:string="assets/header1.jpg";
btnStatus:boolean=false;
 // public myId="testId";ng
  constructor() { }

  ngOnInit() {
  }
 changeTitle()
 {
  this.pageTitle="Data Binding";
 }

}
