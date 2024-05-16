import { Injectable, inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, share } from 'rxjs';
import { ICreateCustomerCommand, ICustomerViewModel, IUpdateCustomerCommand } from '../shared/interfaces';
import { URL_CUSTOMER_CREATE, URL_CUSTOMER_DELETE, URL_CUSTOMER_GET_BY_ID, URL_CUSTOMER_GET_LIST, URL_CUSTOMER_UPDATE } from '../shared/constants';

@Injectable({
  providedIn: 'root'
})
export class CustomerService {
  http = inject(HttpClient);

  createCustomer(request: ICreateCustomerCommand): Observable<ICustomerViewModel> {
    return this.http.post<ICustomerViewModel>(URL_CUSTOMER_CREATE, request).pipe(share());
  }

  updateCustomer(request: IUpdateCustomerCommand): Observable<ICustomerViewModel> {
    return this.http.put<ICustomerViewModel>(URL_CUSTOMER_UPDATE, request).pipe(share());
  }
     
  deleteCustomer(id: number): Observable<ICustomerViewModel> {
    return this.http.delete<ICustomerViewModel>(`${URL_CUSTOMER_DELETE}/${id}`).pipe(share());
  }
  
  getCustomerById(id: number): Observable<ICustomerViewModel> {
    return this.http.get<ICustomerViewModel>(`${URL_CUSTOMER_GET_BY_ID}/${id}`).pipe(share());
  }

  getCustomerList(getAll: boolean, keyword: string): Observable<ICustomerViewModel[]> {
    return this.http.get<ICustomerViewModel[]>(`${URL_CUSTOMER_GET_LIST}?getAll=${getAll}&keyword=${keyword}`).pipe(share());
  }
}
