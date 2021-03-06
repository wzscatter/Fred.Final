import { Component, Input, OnInit } from '@angular/core';
import { ClientService } from 'src/app/core/service/client.service';
import { Client} from 'src/app/shared/models/client';
@Component({
  selector: 'app-clients',
  templateUrl: './client-card.component.html',
  styleUrls: ['./client-card.component.css']
})
export class ClientCardComponent implements OnInit {
  // this property will be available to view so that it can use to display data
  // this property will be available to view so that it can use to display data
  @Input()clients!: Client[];
  constructor(private clientService: ClientService) { }
  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }
  // this were we call our API to get the data
  ngOnInit() {
    console.log('inside ngOnInit method');
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