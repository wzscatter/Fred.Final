import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { InteractionService } from '../core/service/interaction.service';
import { Interaction } from '../shared/models/interaction';
@Component({
  selector: 'app-Interaction',
  templateUrl: './Interaction.component.html',
  styleUrls: ['./Interaction.component.css']
})
export class InteractionComponent implements OnInit {
  // this property will be available to view so that it can use to display data
  now: number = Date.now();
  d: string = new Date(this.now).toISOString();
  errFlg: boolean = false;
  tab: number = 1;
  interaction: Interaction = {
    id: 0,
    clientId: 0,
    employeeId:0,
    intype:'',
    intDate:'',
    remarks:''

  };

  returnUrl: string = "";
  interactionUrl:string="";
  constructor(private interactionService: InteractionService, private router: Router, 
    private route: ActivatedRoute) { }

  ngOnChanges() {
    console.log('inside ngOnChanges method');
  }
  // this were we call our API to get the data
  ngOnInit(): void {
    this.route.queryParams.subscribe(
      (params) => (this.returnUrl = params.returnUrl || '/')
    );
  }
  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }


  submit(buttonType: string) {
    console.log(this.interaction);
    console.log(buttonType)
    if (buttonType == 'Create') {
      this.interactionService.createInteraction(this.interaction).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      );
    } else if (buttonType == 'Update') {
      this.interactionService.updateInteraction(this.interaction).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      )
    } else if (buttonType == 'Delete') {
      this.interactionService.deleteInteraction(this.interaction.id).subscribe(
        (response: any) => {
          this.errFlg = false;
          this.router.navigate([this.returnUrl]);
        }
        
      );
    } else  if (buttonType == 'Search'){
      this.interactionService.getInteraction(this.interaction.id).subscribe(
        (response: any) => { 
          // this.errFlg = false;
          // this.router.navigate(['']);myObservable.subscribe(
          console.log(response)
          this.interaction = response
        }
      );
    }     
    // else {
    //   this.interactionService.getByEmployeeId(this.interaction.employeeId).subscribe(
    //     (response: any) => {

    //       // this.errFlg = false;
    //       // this.router.navigate(['']);myObservable.subscribe(
    //       console.log(response)
    //       this.interaction = response
    //     }
    //   );
    // }
  }
}