import { Component, Input, OnInit } from '@angular/core';
import { EmployeeService } from '../../../core/service/employee.service';
import { Employee} from '../../../shared/models/employee';
@Component({
  selector: 'app-employees',
  templateUrl: './employee-card.component.html',
  styleUrls: ['./employee-card.component.css']
})
export class EmployeeCardComponent implements OnInit {


  @Input()employees!: Employee[];
  constructor(private employeeService: EmployeeService) { }
  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }

  ngOnInit() {
    console.log('inside ngOnInit method');
    this.employeeService.getAllEmployees().subscribe(
      g => {
        this.employees = g;
      }
    )
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }
}