import { Component, Inject } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-generic-dialog',
  templateUrl: './generic-dialog.html',
  styleUrls: ['./generic-dialog.css']
})
export class GenericDialog {
  message: string = ""
  teste: any;
  constructor(
    @Inject(MAT_DIALOG_DATA) public data: any,
    public dialogRef: MatDialogRef<GenericDialog>,
  ) { this.message = data.message; }

  onConfirm = () => this.dialogRef.close('Ok');
  onCancel = () => this.dialogRef.close('Cancel');
}