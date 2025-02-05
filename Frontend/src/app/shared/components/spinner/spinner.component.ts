import { Component, Injectable } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';

@Component({
  selector: 'app-spinner',
  templateUrl: './spinner.component.html',
  styleUrls: ['./spinner.component.css'],
  standalone: true,
  imports: [MatProgressSpinnerModule],
})

@Injectable({
  providedIn: 'root',
})

export class SpinnerComponent { }
