import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { UserService } from 'src/app/core/services/UserService';
import { UserInsert, UserUpdate, User } from 'src/app/core/models/User';

@Component({
  selector: 'app-user-dialog',
  templateUrl: './user-dialog.component.html',
  styleUrls: ['./user-dialog.component.css']
})
export class UserDialogComponent {
  user: User;
  isEditMode: boolean = false;

  constructor(
    public dialogRef: MatDialogRef<UserDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: User,
    private userService: UserService
  ) {
    this.isEditMode = !!data;
    this.user = data ? { ...data } : new User();
  }

  save() {
    if (this.isEditMode) {
      const userUpdate: UserUpdate = { ...this.user };
      this.userService.Update(userUpdate).subscribe(() => this.dialogRef.close(true));
    } else {
      const userInsert: UserInsert = { ...this.user };
      this.userService.Create(userInsert).subscribe(() => this.dialogRef.close(true));
    }
  }
}
