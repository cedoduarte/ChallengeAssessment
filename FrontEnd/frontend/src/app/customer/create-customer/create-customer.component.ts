import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CustomerService } from '../../services/customer.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-create-customer',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [CustomerService],
  templateUrl: './create-customer.component.html',
  styleUrl: './create-customer.component.css'
})
export class CreateCustomerComponent {
  customerService = inject(CustomerService);
  toastr = inject(ToastrService);

  createCustomerForm = new FormGroup({
    firstName: new FormControl("", Validators.required),
    lastName: new FormControl("", Validators.required),
    email: new FormControl("", Validators.required),
  });

  handleSubmit() {
    const firstName: string = this.createCustomerForm.value.firstName!;
    const lastName: string = this.createCustomerForm.value.lastName!;
    const email: string = this.createCustomerForm.value.email!;

    if (firstName.length === 0) {
      this.toastr.error("The First Name cannot be empty!");
      return;
    }
    if (lastName.length === 0) {
      this.toastr.error("The Last Name cannot be empty!");
      return;
    }
    if (email.length === 0) {
      this.toastr.error("The email cannot be empty!");
      return;
    }

    this.customerService.createCustomer({
      firstName,
      lastName,
      email
    }).subscribe(customerObject => {
      this.toastr.success("Customer created successfully!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
