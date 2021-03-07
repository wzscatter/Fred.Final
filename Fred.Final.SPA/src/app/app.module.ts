import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule} from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ClientComponent } from './client/client.component';
import { EmployeeComponent } from './employee/employee.component';
import { InteractionComponent } from './interaction/interaction.component';
import { HeaderComponent } from './core/layout/header/header.component';
import { HomeComponent } from './home/home.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {CliInteractionCardComponent} from './shared/components/cli-interaction-card/cli-interaction-card.component'
import { ClientCardComponent } from './shared/components/client-card/client-card.component';
import { FormsModule,ReactiveFormsModule } from '@angular/forms';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { EmployeeCardComponent } from './shared/components/employee-card/employee-card.component';
import { EmpInteractionCardComponent } from './shared/components/emp-interaction-card/emp-interaction-card.component';



@NgModule({
  declarations: [
    AppComponent,
    EmployeeComponent,
    EmpInteractionCardComponent,
    EmployeeCardComponent,
    ClientCardComponent,
    ClientComponent,
    CliInteractionCardComponent,
    HomeComponent,

    HeaderComponent,

    InteractionComponent,
    NotFoundComponent,

    
  ],
  imports: [
    BrowserModule,


    AppRoutingModule,
    NgbModule,
    HttpClientModule,
    FormsModule,ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
