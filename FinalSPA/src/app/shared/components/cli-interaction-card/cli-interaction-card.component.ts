import { Component, OnDestroy, OnInit } from '@angular/core';
import { Interaction } from '../../models/interaction';
import { InteractionService } from 'src/app/core/service/interaction.service';
import { ActivatedRoute } from '@angular/router';
import { ClientService } from 'src/app/core/service/client.service';
import { Client } from '../../models/client';

@Component({
  selector: 'app-cli-interaction-card',
  // templateUrl: './cli-interaction-card.component.html',
  template:`
        <ul *ngIf="interactions.length===0">
          <h5>Sorry, we didn't find any interaction related with this client</h5>
        </ul>
        <ul  *ngFor="let it of interactions">
            <li>ClientID:{{it.clientId}}</li>
            <li>EmloyeeId:{{it.employeeId}}</li>
            <li>Type:{{it.inType}}</li>
            <li>Date:{{it.intDate}}</li>
            <li>Remarks:{{it.remarks}}</li>
            <li>Interaction:{{it.id}}</li>
        </ul>`
           ,
  styleUrls: ['./cli-interaction-card.component.css']
})
export class CliInteractionCardComponent implements OnInit,OnDestroy {
  clientId!: number;
  interactions :any;
  private sub:any;
  private phone!: Client;
  constructor(private clientService: ClientService,private interactionService: InteractionService,private router: ActivatedRoute) { }
  ngOnDestroy(): void {
    throw new Error('Method not implemented.');
  }

  ngOnInit() {

        // this.clientId = this.router.snapshot.params.id;
      
      this.sub = this.router.params.subscribe(params=>{this.clientId = +params['id'];});
      this.interactions= this.interactionService.getByClientId(this.clientId)
      .subscribe(g => {
        this.interactions = g;
        console.log("Succed get the interactions")
      });
    }

  
}


