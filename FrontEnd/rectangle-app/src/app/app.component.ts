import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { RectangleComponent } from './rectangle/rectangle/rectangle.component';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [CommonModule, RectangleComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'rectangle-app';
}
