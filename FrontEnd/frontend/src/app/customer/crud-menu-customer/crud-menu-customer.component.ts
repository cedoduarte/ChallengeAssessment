import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { Router } from '@angular/router';

@Component({
  selector: 'app-crud-menu-customer',
  standalone: true,
  imports: [RouterOutlet],
  templateUrl: './crud-menu-customer.component.html',
  styleUrl: './crud-menu-customer.component.css'
})
export class CrudMenuCustomerComponent {
  router = inject(Router);

  goCreateCustomer() {
    this.router.navigate(["/create-customer"]);
  }

  goReadCustomer() {
    this.router.navigate(["/read-customer"]);
  }

  goUpdateCustomer() {
    this.router.navigate(["/update-customer"]);
  }

  goDeleteCustomer() {
    this.router.navigate(["/delete-customer"]);
  }
}
