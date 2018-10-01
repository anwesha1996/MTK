import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-feedback-form',
  templateUrl: './feedback-form.component.html',
  styleUrls: ['./feedback-form.component.css']
})
export class FeedbackFormComponent implements OnInit {

public Name="";
public MID="";
public FEEDBACK="";
 a=[];
  constructor() { }

  ngOnInit() {
  }
 submit()
 {
this.a.push(this.Name);
this.a.push(this.MID);
this.a.push(this.FEEDBACK);
 }
}
