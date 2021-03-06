import { Component, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../../../core/service/employee.service';
import { Employee} from '../../../shared/models/employee';
@Component({
  selector: 'app-employees',
  templateUrl: './employee-card.component.html',
  styleUrls: ['./employee-card.component.css']
})
export class EmployeeCardComponent implements OnInit {
  // this property will be available to view so that it can use to display data
  // this property will be available to view so that it can use to display data
  @Input()employees!: Employee[];
  constructor(private employeeService: EmployeeService) { }
  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }
  // this were we call our API to get the data
  ngOnInit() {
    console.log('inside ngOnInit method');
    this.employeeService.getAllEmployee().subscribe(
      g => {
        this.employees = g;
        console.log('employees')
      }
    )
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }
}