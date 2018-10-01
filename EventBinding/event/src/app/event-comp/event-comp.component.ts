import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-event-comp',
  templateUrl: './event-comp.component.html',
  styleUrls: ['./event-comp.component.css']
})
export class EventCompComponent implements OnInit {

  constructor() { }
  public greeting:any;

  ngOnInit() {
  }
  myFunction(event)
  {
console.log('Welcome to Event Binding');
  }
  myFunction1(event)
  {
 this.greeting='welcome welcome welcome';
  }
}
