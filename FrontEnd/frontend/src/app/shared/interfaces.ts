export interface ICustomerViewModel {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
    createdDateTime: string;
    lastUpdatedDateTime: string;
}

export interface ICreateCustomerCommand {
    firstName: string;
    lastName: string;
    email: string;
}

export interface IUpdateCustomerCommand {
    id: number;
    firstName: string;
    lastName: string;
    email: string;
}