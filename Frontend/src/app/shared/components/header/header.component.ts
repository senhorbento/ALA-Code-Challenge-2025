import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from 'src/app/core/services/UserService';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
  user: string | null = "";
  accessLevel: string | null = "";
  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.user = this.userService.GetCurrentUser();
  }

  Logout() {
    this.userService.logout();
    this.router.navigate(['']);
  }

  AdminButton = () => this.router.navigate(['/adminbutton']);
  Button = () => this.router.navigate(['/button']);
  DropdownbuttonFoo = () => this.router.navigate(['dropdownbutton/foo']);
  DropdownbuttonBar = () => this.router.navigate(['dropdownbutton/bar']);

}
