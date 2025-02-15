import { Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { Product } from 'src/app/core/models/Product';
import { Purchase } from 'src/app/core/models/Purchase'; 
import { ProductService } from 'src/app/core/services/ProductService';
import { PurchaseService } from 'src/app/core/services/PurchaseService'; 
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatDialog } from '@angular/material/dialog';
import { ProductComponent } from 'src/app/shared/dialogs/product/product.component'; 

@Component({
  selector: 'app-main-table',
  templateUrl: './main-table.component.html',
  styleUrls: ['./main-table.component.css'],
})

export class MainTableComponent implements OnInit {
  displayedColumnsProducts: string[] = ['id', 'name', 'price', 'Edit', 'Delete'];
  displayedColumnsPurchases: string[] = ['id', 'userID', 'orderDate', 'total', 'Edit', 'Delete']; 

  productList: MatTableDataSource<Product> = new MatTableDataSource<Product>();
  purchaseList: MatTableDataSource<Purchase> = new MatTableDataSource<Purchase>(); 

  pageSizes: number[] = [25, 50, 100];
  productLength: number = 0;
  purchaseLength: number = 0;

  @ViewChild('productPaginator') productPaginator!: MatPaginator; 
  @ViewChild('purchasePaginator') purchasePaginator!: MatPaginator;

  @ViewChild(MatSort) sort!: MatSort; 

  constructor(
    private productService: ProductService,
    private purchaseService: PurchaseService, 
    private dialog: MatDialog
  ) { }

  ngOnInit(): void {
    this.refreshProducts();
    this.refreshPurchases();
  }

  applyFilter(event: Event, isPurchase: boolean) {
    const filterValue = (event.target as HTMLInputElement).value;
    const dataSource = isPurchase ? this.purchaseList : this.productList;

    dataSource.filter = filterValue.trim().toLowerCase();

    if (dataSource.paginator) {
      dataSource.paginator.firstPage();
    }
  }

  refreshProducts() {
    this.productService.GetList().subscribe({
      next: data => {
        this.productList = new MatTableDataSource(data);
        this.productList.paginator = this.productPaginator; 
        this.productList.sort = this.sort;
        this.productLength = this.productList._filterData.length;
        this.adjustPageSizes(this.productLength);
        console.log("Products:", this.productList.data);
      },
      error: error => console.error("Error loading products:", error)
    });
  }

  refreshPurchases() {
    this.purchaseService.GetList().subscribe({ 
      next: data => {
        this.purchaseList = new MatTableDataSource(data);
        this.purchaseList.paginator = this.purchasePaginator; 
        this.purchaseList.sort = this.sort;
        this.purchaseLength = this.purchaseList._filterData.length;
        this.adjustPageSizes(this.purchaseLength);
        console.log("Purchases:", this.purchaseList.data);
      },
      error: error => console.error("Error loading purchases:", error)
    });
  }

  adjustPageSizes(length: number) {
    if (length > 100 && !this.pageSizes.includes(length)) {
      this.pageSizes = [...this.pageSizes, length];
    }
  }

  insertProduct = () => this.openDialog("Insert Product", undefined, true); 
  insertPurchase = () => this.openDialog("Insert Purchase", undefined, false);

  editProduct = (obj: Product) => this.openDialog("Edit Product", obj, true); 
  editPurchase = (obj: Purchase) => this.openDialog("Edit Purchase", obj, false); 

  removeProduct = (id: number) => console.log("remove Product" + id);
  removePurchase = (id: number) => console.log("remove Purchase" + id);

  openDialog(title: string, object?: Product | Purchase, isPurchase: boolean = true) {
    this.dialog.open(ProductComponent, { 
      disableClose: true,
      data: {
        title: title,
        object: object,
        isPurchase: isPurchase 
      }
    }).afterClosed().subscribe(() => {
      this.refreshProducts();
      this.refreshPurchases();
    });
  }
}