import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { UserService } from 'src/app/core/services/UserService';
import { User } from 'src/app/core/models/User';
import { UserDialogComponent } from './user-dialog.component';

@Component({
  selector: 'app-user-page',
  templateUrl: './user-page.component.html',
  styleUrls: ['./user-page.component.css']
})
export class UserPageComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'email', 'role', 'actions'];
  userList: User[] = [];
  isAdmin: boolean = false;

  constructor(private userService: UserService, private dialog: MatDialog) { }

  ngOnInit(): void {
    this.loadUsers();
    this.isAdmin = this.userService.GetCurrentRole() === 'admin';
  }

  loadUsers() {
    this.userService.GetAll().subscribe(users => {
      this.userList = users;
    });
  }

  openDialog(user?: User) {
    this.dialog.open(UserDialogComponent, {
      width: '400px',
      data: user ? { ...user } : null
    }).afterClosed().subscribe(result => {
      if (result) this.loadUsers();
    });
  }
}
