import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from '../core/service/employee.service';
import { Employee } from '../shared/models/employee';
@Component({
  selector: 'app-Employee',
  templateUrl: './Employee.component.html',
  styleUrls: ['./Employee.component.css']
})
export class EmployeeComponent implements OnInit {
  // this property will be available to view so that it can use to display data
  now: number = Date.now();
  d: string = new Date(this.now).toISOString();
  errFlg: boolean = false;
  tab: number = 1;
  employee: Employee = {
    id: 0,
    name: '',
    password:'',
    designation:'',

  };

  returnUrl: string = "";
  employeeUrl:string="";
  constructor(private employeeService: EmployeeService, private router: Router, 
    private route: ActivatedRoute) { }

  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }
  // this were we call our API to get the data
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      (params) => (this.returnUrl = params.returnUrl || '/')
    );
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }


  submit(buttonType: string) {
    console.log(this.employee);
    console.log(buttonType)
    if (buttonType == 'Create') {
      this.employeeService.createEmployee(this.employee).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      );
    } else if (buttonType == 'Update') {
      this.employeeService.updateEmployee(this.employee).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      )
    } else if (buttonType == 'Delete') {
      this.employeeService.deleteEmployee(this.employee.id).subscribe(
        (response: any) => {
          this.errFlg = false;
          this.router.navigate([this.returnUrl]);
        }
        
      );
    } else {
      this.employeeService.getEmployee(this.employee.id).subscribe(
        (response: any) => {
          // this.errFlg = false;
          // this.router.navigate(['']);myObservable.subscribe(
          console.log(response)
          this.employee = response
        }
      );
    }
  }
}