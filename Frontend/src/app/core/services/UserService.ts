import { BehaviorSubject, catchError, map } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from './Constants';
import { User, UserInsert, UserUpdate, UserLogin, UserLoginResponse } from '../models/User';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private BASE_URL: string = Constants.USER;
  private currentUserSource = new BehaviorSubject<UserLoginResponse | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) { }

  // Métodos de autenticação
  GetCurrentUser = () => sessionStorage.getItem('name');
  GetCurrentRole = () => sessionStorage.getItem('roles');
  GetCurrentToken = () => sessionStorage.getItem('token');

  GetAll = () => this.http.get<User[]>(`${this.BASE_URL}/Read`);
  
  GetById = (id: number) => this.http.get<User>(`${this.BASE_URL}/Read/${id}`);
  
  Create = (user: UserInsert) => this.http.post(`${this.BASE_URL}/Create`, user);
  
  Update = (user: UserUpdate) => this.http.put(`${this.BASE_URL}/Update`, user);
  
  Delete = (id: number) => this.http.delete(`${this.BASE_URL}/Delete/${id}`);

  Login = (credentials: UserLogin) => this.http.post<UserLoginResponse>(`${this.BASE_URL}/Login/Login`, credentials).pipe(
    map((response: UserLoginResponse) => {
      sessionStorage.setItem('token', response.token);
      sessionStorage.setItem('name', response.name);
      sessionStorage.setItem('roles', response.role);
      this.currentUserSource.next(response);
      return response;
    }),
    catchError(error => { throw error; })
  );

  logout = () => {
    sessionStorage.clear();
    this.currentUserSource.next(null);
  }
}