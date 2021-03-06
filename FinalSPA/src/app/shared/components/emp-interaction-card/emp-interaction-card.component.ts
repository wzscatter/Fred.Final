
import { Component, OnDestroy, OnInit } from '@angular/core';
import { Interaction } from '../../models/interaction';
import { InteractionService } from 'src/app/core/service/interaction.service';
import { ActivatedRoute } from '@angular/router';
import { EmployeeService } from 'src/app/core/service/employee.service';
import { Employee } from '../../models/employee';
@Component({
  selector: 'app-emp-interaction-card',
  // templateUrl: './emp-interaction-card.component.html',
  template:`<div>show detials for employeeId:{{employeeId}}</div>
        <ol *ngFor="let it of interactions">
            <li>ClientID:{{it.clientId}}</li>
            <li>EmloyeeId:{{it.employeeId}}</li>
            <li>Type:{{it.inType}}</li>
            <li>Date:{{it.intDate}}</li>
            <li>Remarks:{{it.remarks}}</li>
        </ol>`,
  styleUrls: ['./emp-interaction-card.component.css']
})
export class EmpInteractionCardComponent implements OnInit,OnDestroy {
  employeeId!: number;
  interactions :any;
  private sub:any;
  constructor(private employeeService: EmployeeService,private interactionService: InteractionService,private router: ActivatedRoute) { }
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit() {

        // this.employeeId = this.router.snapshot.params.id;
      
      this.sub = this.router.params.subscribe(params=>{this.employeeId = +params['id'];});
      this.interactions= this.interactionService.getByEmployeeId(this.employeeId)
      .subscribe(g => {
        this.interactions = g;
        console.log("Succed get the interactions")
      });
    }

  
}


