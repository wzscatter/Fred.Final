// import { Component, OnInit } from '@angular/core';
// import { ActivatedRoute, Router } from '@angular/router';
// import { ClientService } from '../core/service/client.service';
// import { Client} from '../shared/models/client';
// @Component({
//   selector: 'app-Client',
//   templateUrl: './client.component.html',
//   styleUrls: ['./client.component.css']
// })
// export class ClientComponent implements OnInit {
//   now : number = Date.now();
//   d : string = new Date(this.now).toISOString();
//   errMsg : string='';
//   errFlg : boolean = false;
//   tab: number = 1;
//   client: Client = {
//     email: '',
//     id: 0,
//     name: '',
//     phone: '',
//     address: '',
//     addedOn: this.d,
//     clicked: false
//   };
//   buttonType!: string;
//   returnUrl!: string;
//   constructor(private clientService: ClientService, 
//     private router: Router, 
//     private route: ActivatedRoute) { }

//   ngOnInit(): void {
//     this.route.queryParams.subscribe(
//       (params) => (this.returnUrl = params.returnUrl || '/')
//     );
//   }
//   submit(buttonType: string) {
//     console.log(this.client);
//     console.log(buttonType)
//     if (buttonType == 'Create') {
//       this.clientService.createClient(this.client).subscribe(
//         (response: any) => {
//           if (response) {
//             this.errFlg = false;
//             this.router.navigate([this.returnUrl]);
//           }
//         }, 
//         (err: any) => {
//           this.errMsg = err.message;
//           this.errFlg = true;
//           console.log(err);
//         }
//       );
// } else if (buttonType == 'Update') {
//   this.clientService.updateClient(this.client).subscribe(
//     (response:any) => {
//       if (response) {
//         this.errFlg = false;
//         this.router.navigate([this.returnUrl]);
//       }
//     }

//   )
// } else {
//   this.clientService.deleteClient(this.client.id).subscribe(
//     (response:any) => {
//         this.errFlg = false;
//         this.router.navigate([this.returnUrl]);
//     }, 
//     (err: any) => {
//       this.errMsg = err.message;
//       this.errFlg = true;
//       if (err.status == 404) {
//         this.errMsg = "User Not Found";
//       }
//       console.log(err);
//     }
//   );
//     }
//   }
// }
//----------------------------------------------------------------------------------------------------------------------------------
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ClientService } from '../core/service/client.service';
import { Client } from '../shared/models/client';
@Component({
  selector: 'app-Employee',
  templateUrl: './Client.component.html',
  styleUrls: ['./Client.component.css']
})
export class ClientComponent implements OnInit {
  // this property will be available to view so that it can use to display data
  now: number = Date.now();
  d: string = new Date(this.now).toISOString();
  errFlg: boolean = false;
  tab: number = 1;
  client: Client = {
    id: 0,
    name: '',
    email: '',
    phone: '',
    addedOn: '',
    address: '',
    clicked: true
  };

  returnUrl: string = "";
  constructor(private clientService: ClientService, private router: Router, 
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
    console.log(this.client);
    console.log(buttonType)
    if (buttonType == 'Create') {
      this.clientService.createClient(this.client).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      );
    } else if (buttonType == 'Update') {
      this.clientService.updateClient(this.client).subscribe(
        (response: any) => {
          if (response) {
            this.errFlg = false;
            this.router.navigate([this.returnUrl]);
          }
        }

      )
    } else {
      this.clientService.deleteClient(this.client.id).subscribe(
        (response: any) => {
          this.errFlg = false;
          this.router.navigate([this.returnUrl]);
        }
        
      );
    }

  }
}