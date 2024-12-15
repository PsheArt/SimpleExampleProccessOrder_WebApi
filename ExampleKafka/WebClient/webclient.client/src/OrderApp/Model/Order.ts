export interface Order {
    Id: string;
    Product: string;
    Quantity: number;
    Price: number;
    UserEmail: string;
    Created: Date;
    Paid: boolean;
}
