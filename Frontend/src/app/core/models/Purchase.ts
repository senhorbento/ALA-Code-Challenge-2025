export class Purchase {
  id: number = -1;
  userID: number = -1;
  orderDate: Date = new Date();
  total: number = -1;
}

export class PurchaseInsert {
  userID: number = -1;
  orderDate: Date = new Date();
  total: number = -1;
}

export class PurchaseUpdate {
  id: number = -1;
  userID: number = -1;
  orderDate: Date = new Date();
  total: number = -1;
}