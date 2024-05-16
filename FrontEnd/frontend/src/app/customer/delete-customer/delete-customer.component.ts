import { Component, inject, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { ICustomerViewModel } from '../../shared/interfaces';

@Component({
  selector: 'app-delete-customer',
  standalone: true,
  imports: [HttpClientModule],
  providers: [CustomerService],
  templateUrl: './delete-customer.component.html',
  styleUrl: './delete-customer.component.css'
})
export class DeleteCustomerComponent implements OnInit {
  customerService = inject(CustomerService);
  toastr = inject(ToastrService);
  customerList: ICustomerViewModel[] = [];

  ngOnInit() {
    this.populateCustomerTable();
  }

  deleteCustomer(id: number) {
    this.customerService.deleteCustomer(id)
    .subscribe(customerObject => {
      this.populateCustomerTable();
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }

  populateCustomerTable() {
    this.customerService.getCustomerList(true, "")
    .subscribe(customerArray => {
      this.customerList = customerArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
