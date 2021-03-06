import { Component, OnInit } from '@angular/core';
import { EmployeeService } from '../core/service/employee.service';
import { Employee} from '../shared/models/employee';
@Component({
  selector: 'app-Employee',
  templateUrl: './Employee.component.html',
  styleUrls: ['./Employee.component.css']
})
export class EmployeeComponent implements OnInit {
  // this property will be available to view so that it can use to display data
  now : number = Date.now();
  d : string = new Date(this.now).toISOString();
  errFlg : boolean = false;
  tab: number = 1;
  Employee: Employee = {
    id: 0,
    name: '',
    password: '',
    designatin:'',

  }
  route: any;
  returnUrl: string="";
  constructor(private employeeService: EmployeeService) { }

  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }
  // this were we call our API to get the data
  ngOnInit() {
    this.route.queryParams.subscribe(
      (params: { returnUrl: string; }) => (this.returnUrl = params.returnUrl || '/')
    );
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }



}