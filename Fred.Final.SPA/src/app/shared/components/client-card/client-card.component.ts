import { Component, Input, OnInit } from '@angular/core';
import { ClientService } from 'src/app/core/service/client.service';
import { Client} from 'src/app/shared/models/client';
@Component({
  selector: 'app-clients',
  templateUrl: './client-card.component.html',
  styleUrls: ['./client-card.component.css']
})
export class ClientCardComponent implements OnInit {
  

  @Input()clients!: Client[];
  constructor(private clientService: ClientService) { }
  ngOnChanges() {
    console.log('inside client-card ngOnChanges method');
  }
  
  ngOnInit() {
    console.log('inside client-card ngOnInit method');
    this.clientService.getAllClients().subscribe(
      g => {
        this.clients = g;
        console.log('Clients')
      }
    )
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }
}