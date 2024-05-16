import { Component, inject } from '@angular/core';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';
import { CustomerService } from '../../services/customer.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-update-customer',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, HttpClientModule],
  providers: [CustomerService],
  templateUrl: './update-customer.component.html',
  styleUrl: './update-customer.component.css'
})
export class UpdateCustomerComponent {
  customerService = inject(CustomerService);
  toastr = inject(ToastrService);

  updateCustomerForm = new FormGroup({
    customerId: new FormControl("", Validators.required),
    firstName: new FormControl("", Validators.required),
    lastName: new FormControl("", Validators.required),
    email: new FormControl("", Validators.required),
  });

  idChanged(event: any) {
    const id: number = parseInt(event.target.value);
    this.customerService.getCustomerById(id)
    .subscribe(customerObject => {
      this.updateCustomerForm.setValue({
        customerId: `${id}`,
        firstName: customerObject.firstName!,
        lastName: customerObject.lastName!,
        email: customerObject.email!
      });
    }, errorObject => {
      this.updateCustomerForm.setValue({
        customerId: "",
        firstName: "",
        lastName: "",
        email: ""
      });
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }

  handleSubmit() {
    const customerId: string = this.updateCustomerForm.value.customerId!;
    const firstName: string = this.updateCustomerForm.value.firstName!;
    const lastName: string = this.updateCustomerForm.value.lastName!;
    const email: string = this.updateCustomerForm.value.email!;

    if (customerId.length === 0) {
      this.toastr.error("The Customer ID cannot be empty!");
      return;
    }
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

    this.customerService.updateCustomer({
      id: parseInt(customerId),
      firstName,
      lastName,
      email
    }).subscribe(customerObject => {
      this.toastr.success("Customer updated successfully!");
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
