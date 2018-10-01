import { Component, OnInit,Input } from '@angular/core';

@Component({
  selector: 'app-dispc',
  templateUrl: './dispc.component.html',
  styleUrls: ['./dispc.component.css']
})
export class DispcComponent implements OnInit {

  constructor() { }
  @Input() public parent ;
  @Input() public parent1;
  @Input() public parent2;
  ngOnInit() {
  }
  

}
