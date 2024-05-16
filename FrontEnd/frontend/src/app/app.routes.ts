import { Routes } from '@angular/router';
import { CrudMenuCustomerComponent } from './customer/crud-menu-customer/crud-menu-customer.component';
import { CreateCustomerComponent } from './customer/create-customer/create-customer.component';
import { ReadCustomerComponent } from './customer/read-customer/read-customer.component';
import { UpdateCustomerComponent } from './customer/update-customer/update-customer.component';
import { DeleteCustomerComponent } from './customer/delete-customer/delete-customer.component';

export const routes: Routes = [
    {
        path: "",
        component: CrudMenuCustomerComponent,
        children: [
            {
                path: "create-customer",
                component: CreateCustomerComponent
            },
            {
                path: "read-customer",
                component: ReadCustomerComponent
            },
            {
                path: "update-customer",
                component: UpdateCustomerComponent
            },
            {
                path: "delete-customer",
                component: DeleteCustomerComponent
            }
        ]
    }
];
