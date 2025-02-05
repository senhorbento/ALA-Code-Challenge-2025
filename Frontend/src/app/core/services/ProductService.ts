import { catchError, map } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from './Constants';
import { Product, ProductInsert, ProductUpdate } from '../models/Product';

@Injectable({
  providedIn: 'root',
})

export class ProductService {
  constructor(private http: HttpClient) { }

  GetList = () => this.http.get<Product[]>(`${Constants.PRODUCT}/Read`).pipe(
    map((product: Product[]) => product),
    catchError(error => { throw error; })
  );

  GetById = (id: number) => this.http.get<Product>(`${Constants.PRODUCT}/Read/${id}`).pipe(
    map((product: Product) => product),
    catchError(error => { throw error; })
  );

  Insert = (obj: ProductInsert) => this.http.post(`${Constants.PRODUCT}/Create`, obj).pipe(
    catchError(error => { throw error; })
  );

  UpdateById = (obj: ProductUpdate) => this.http.put(`${Constants.PRODUCT}/UpdateById`, obj).pipe(
    catchError(error => { throw error; })
  );
  RemoveById = () => { }

}
