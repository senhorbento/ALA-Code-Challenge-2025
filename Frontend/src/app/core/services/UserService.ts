import { BehaviorSubject, map } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Constants } from './Constants';
import { UserLogin, UserLoginResponse } from '../models/User';

@Injectable({
  providedIn: 'root',
})

export class UserService {
  private BASE_URL: string = Constants.USER;
  private currentUserSource = new BehaviorSubject<any | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  getCurrentUser = () => sessionStorage.getItem('name');
  getCurrentAccessLevel = () => sessionStorage.getItem('roles');
  getCurrentToken = () => sessionStorage.getItem('token');

  constructor(private http: HttpClient) { }

  Login = (user: UserLogin) => this.http.post<UserLoginResponse>(`${this.BASE_URL}/Validate/`, user).pipe(
    map((user: UserLoginResponse) => {
      sessionStorage.setItem('roles', user.role);
      sessionStorage.setItem('name', user.name);
      sessionStorage.setItem('token', user.token);
    }
    ));

  Logout = () => {
    sessionStorage.clear();
  }
}
