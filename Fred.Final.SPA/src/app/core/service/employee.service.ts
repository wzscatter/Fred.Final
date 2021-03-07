import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Employee } from 'src/app/shared/models/employee';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  constructor(private apiService: ApiService) { }
  
  getAllEmployees(): Observable<Employee[]> {

    return this.apiService.getAll('Employee/All');
  }
    
  getEmployee(id:number): Observable<Employee> {
   
    return this.apiService.getOne('Employee',id);
  }
  createEmployee(resource: any): Observable<Employee> {
    return this.apiService.create('Employee/add', resource);
  }
  updateEmployee(resource: any): Observable<Employee> {
    return this.apiService.update('Employee/update?id=', resource);
  }
  deleteEmployee(resource: any): Observable<Employee> {
    return this.apiService.delete('Employee/delete?id=' + resource);
  }

}
