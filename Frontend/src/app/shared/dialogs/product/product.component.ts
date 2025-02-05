import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Product, ProductInsert, ProductUpdate } from 'src/app/core/models/Product';
import { ProductService } from 'src/app/core/services/ProductService';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent implements OnInit {
  title: string = "";
  product: Product = new Product();

  constructor(@Inject(MAT_DIALOG_DATA) public data: any, private productService: ProductService) {
    this.title = this.data.title;
    this.product = this.data.object ?? new Product();
  }

  ngOnInit(): void {

  }

  Insert = () => {
    if(this.title.toLowerCase().includes("insert")){
      const productInsert : ProductInsert = new ProductInsert ();
      productInsert.name = this.product.name;
      productInsert.price = this.product.price;
      this.productService.Insert(productInsert).subscribe();
    }
    else{
      const itemUpdate : ProductUpdate = new ProductUpdate ();
      itemUpdate.id = this.product.id;
      itemUpdate.name = this.product.name;
      itemUpdate.price = this.product.price;
      this.productService.UpdateById(itemUpdate).subscribe();
    }
  }

}
