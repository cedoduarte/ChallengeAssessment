import { Component, inject, OnInit } from '@angular/core';
import { CustomerService } from '../../services/customer.service';
import { HttpClientModule } from '@angular/common/http';
import { ToastrService } from 'ngx-toastr';
import { ICustomerViewModel } from '../../shared/interfaces';

@Component({
  selector: 'app-read-customer',
  standalone: true,
  imports: [HttpClientModule],
  providers: [CustomerService],
  templateUrl: './read-customer.component.html',
  styleUrl: './read-customer.component.css'
})
export class ReadCustomerComponent implements OnInit {
  customerService = inject(CustomerService);
  toastr = inject(ToastrService);
  customerList: ICustomerViewModel[] = [];

  ngOnInit() {
    this.customerService.getCustomerList(true, "")
    .subscribe(customerArray => {
      this.customerList = customerArray;
    }, errorObject => {
      this.toastr.error(errorObject.error.substring(errorObject.error.indexOf("¡"), errorObject.error.indexOf("!") + 1));
    });
  }
}
