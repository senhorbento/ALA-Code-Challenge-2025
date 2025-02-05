import { Injectable } from '@angular/core';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})

export class SnackBar {
  constructor(private _snackBar: MatSnackBar) { }

  open(message: string, isError: boolean) {
    this._snackBar.open(message, '', {
      horizontalPosition: 'right',
      verticalPosition: 'top',
      duration: 5000,
      panelClass: isError ? ['snack-error'] : ['snack-success']
    });
  }
}
