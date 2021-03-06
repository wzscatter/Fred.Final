import { Component, OnDestroy, OnInit } from '@angular/core';
import { Interaction } from '../../models/interaction';
import { InteractionService } from 'src/app/core/service/interaction.service';
import { ActivatedRoute } from '@angular/router';
import { ClientService } from 'src/app/core/service/client.service';
import { Client } from '../../models/client';

@Component({
  selector: 'app-cli-interaction-card',
  // templateUrl: './cli-interaction-card.component.html',
  template:`<div>show detials for clientId:{{clientId}}</div>
        <ol *ngFor="let it of interactions">
            <li>ClientID:{{it.clientId}}</li>
            <li>EmloyeeId:{{it.employeeId}}</li>
            <li>Type:{{it.inType}}</li>
            <li>Date:{{it.intDate}}</li>
            <li>Remarks:{{it.remarks}}</li>
        </ol>
        
  
  
  `
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


