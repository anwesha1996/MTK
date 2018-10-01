import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-disp',
  templateUrl: './disp.component.html',
  styleUrls: ['./disp.component.css']
})
export class DispComponent implements OnInit {
  public Name;
  public Track;
  public Room;
  
   constructor() {}
   ngOnInit() {
   }
   submit(a,b,c)
   {
     this.Name=a;
     this.Track=b;
     this.Room=c;
  // this.a.push(this.Name);
  // this.a.push(this.Track);
  // this.a.push(this.Room);
   }
  

}
