

import { HomeComponent } from './home/home.component';
import { ClientCardComponent } from './shared/components/client-card/client-card.component'

import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { RouterModule, Routes } from '@angular/router';
import { NgModule } from '@angular/core';
import { ClientComponent } from './client/client.component';
import { CliInteractionCardComponent } from './shared/components/cli-interaction-card/cli-interaction-card.component';
import { EmployeeComponent } from './employee/employee.component';
import { EmpInteractionCardComponent } from './shared/components/emp-interaction-card/emp-interaction-card.component';
import { InteractionComponent } from './interaction/interaction.component';

const routes: Routes = [
  {path: "", component : HomeComponent},
  {path: 'client', component: ClientComponent},
  {path:'client/Interactions/:id',component:CliInteractionCardComponent},
  {path: 'employee', component: EmployeeComponent},
  {path:'employee/Interactions/:id',component:EmpInteractionCardComponent},
  {path: 'interaction', component: InteractionComponent},
  {path: "**", component: NotFoundComponent}
 
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
