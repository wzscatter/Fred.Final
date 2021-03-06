import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Interaction } from 'src/app/shared/models/interaction';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class InteractionService {

  constructor(protected apiService: ApiService) { }
  getAllInteractions(): Observable<Interaction[]> {
    return this.apiService.getAll('Interaction/All');
  }
  getInteraction(id:number): Observable<Interaction> {
    return this.apiService.getOne('Interaction', id);
  }
  getByEmployeeId(id:number): Observable<Interaction[]> {
    return this.apiService.getAll('Interaction/Employee', id);
  }
  getByClientId(id:number): Observable<Interaction[]> {
    return this.apiService.getAll('Interaction/Client', id);
  }
  createInteraction(resource: any): Observable<boolean> {
    return this.apiService.create('Interaction/Add', resource);
  }
  updateInteraction(resource: any) {
    return this.apiService.update('Interaction/Update', resource);
  }
  deleteInteraction(resource: any) {
    return this.apiService.delete('Interaction/delete?id=' + resource);
  }
}
