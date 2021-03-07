import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Client } from 'src/app/shared/models/client';
import { ApiService } from './api.service';
@Injectable({
  providedIn: 'root'
})
export class ClientService {
  constructor(private apiService: ApiService) { }
  
  getAllClients(): Observable<Client[]> {

    return this.apiService.getAll('Client/All');
  }
    
  getClient(id:number): Observable<Client> {
   
    return this.apiService.getOne('Client',id);
  }
  createClient(resource: any): Observable<Client> {
    return this.apiService.create('Client/add', resource);
  }
  updateClient(resource: any): Observable<Client> {
    return this.apiService.update('Client/update?id=', resource);
  }
  deleteClient(resource: any): Observable<Client> {
    return this.apiService.delete('Client/delete?id=' + resource);
  }

}