import { Component } from '@angular/core';
import { BreakpointObserver, Breakpoints, BreakpointState } from '@angular/cdk/layout';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-my-nav',
  templateUrl: './my-nav.component.html',
  styleUrls: ['./my-nav.component.css']
})
export class MyNavComponent {

  isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
    .pipe(
      map(result => result.matches)
    );
    
  constructor(private breakpointObserver: BreakpointObserver) {}
  
  mob: string;
  mob1:string;
  mob2:string;
  mob3:string;
  mob4:string;
  mob5:string;
  mob6:string;
  mob7:string;
  mob8:string;
  mob9:string;
  mob10:string;
  clearSortingFilters()
  {
    this.mob = '';
    this.mob1 = ''; 
    this.mob2='';
    this.mob3 = '';
    this.mob4 = '';
    this.mob5 = '';
    this.mob6 = '';
    this.mob7 = '';
    this.mob8 = '';
    this.mob9 = '';
    this.mob10 = '';
  }
}