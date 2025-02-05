import { Component, OnInit } from '@angular/core';
import { UserService } from './core/services/UserService';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'Frontend';
  user: any;
  constructor(private userService : UserService) {}

  ngOnInit(): void {
    this.setCurrentUser();
  }

  setCurrentUser = () => {
    this.user = sessionStorage.getItem('user');
  }

}
