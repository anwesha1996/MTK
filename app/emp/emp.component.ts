import { Component, OnInit } from '@angular/core';
import{EmpserveService} from './shared/empserve.service';

@Component({
  selector: 'app-emp',
  templateUrl: './emp.component.html',
  styleUrls: ['./emp.component.css'],
  providers:[EmpserveService]
})
export class EmpComponent implements OnInit {

  constructor(private employeeservice:EmpserveService) { }

  ngOnInit() {
  }

}
