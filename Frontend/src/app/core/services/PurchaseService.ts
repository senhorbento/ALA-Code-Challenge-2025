import { catchError, map } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from './Constants';
import { Purchase, PurchaseInsert, PurchaseUpdate } from '../models/Purchase';
@Injectable({
  providedIn: 'root',
})

export class PurchaseService {
  constructor(private http: HttpClient) { }

  GetList = () => this.http.get<Purchase[]>(`${Constants.PURCHASE}/Read`).pipe(
    map((purchase: Purchase[]) => purchase),
    catchError(error => { throw error; })
  );

  GetById = (id: number) => this.http.get<Purchase>(`${Constants.PURCHASE}/Read/${id}`).pipe(
    map((purchase: Purchase) => purchase),
    catchError(error => { throw error; })
  );

  Insert = (obj: PurchaseInsert) => this.http.post(`${Constants.PURCHASE}/Create`, obj).pipe(
    catchError(error => { throw error; })
  );

  UpdateById = (obj: PurchaseUpdate) => this.http.put(`${Constants.PURCHASE}/UpdateById`, obj).pipe(
    catchError(error => { throw error; })
  );
  RemoveById = () => { }

}
