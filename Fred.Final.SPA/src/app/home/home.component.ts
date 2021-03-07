import { CompileShallowModuleMetadata } from '@angular/compiler';
import { Component, OnInit } from '@angular/core';
import { ClientService } from "../core/service/client.service"
import { Client } from '../shared/models/client';
import {ClientCard} from "../shared/models/clientCard"
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  clients: Client[] = [];
  constructor(private clientService: ClientService) { }

  ngOnInit(): void {
    this.clientService.getAllClients().subscribe((g) => {
      console.log("call");
      this.clients = g;
      console.log(this.clients);
    
    });
  }

}