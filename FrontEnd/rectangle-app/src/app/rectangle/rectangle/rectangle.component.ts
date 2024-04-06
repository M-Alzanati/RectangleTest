import { CommonModule } from '@angular/common';
import { Component, OnInit, HostListener } from '@angular/core';
import { RectangleService } from '../rectangle.service';

@Component({
  imports: [CommonModule],
  standalone: true,
  selector: 'app-rectangle',
  templateUrl: './rectangle.component.html',
  styleUrls: ['./rectangle.component.css'],
})
export class RectangleComponent implements OnInit {
  width = 0;
  height = 0;
  resizing = false;

  constructor(private rectangleService: RectangleService) {}

  ngOnInit(): void {
    this.rectangleService.getDimensions().subscribe((dimensions) => {
      this.width = dimensions.width;
      this.height = dimensions.height;
    });
  }

  @HostListener('mousedown')
  onMouseDown(): void {
    this.resizing = true;
  }

  @HostListener('mouseup')
  onMouseUp(): void {
    this.resizing = false;
    this.rectangleService
      .updateDimensions({ width: this.width, height: this.height })
      .subscribe();
  }

  @HostListener('mousemove', ['$event'])
  onMouseMove(event: MouseEvent): void {
    if (this.resizing) {
      this.width = event.clientX;
      this.height = event.clientY;
    }
  }

  get perimeter(): number {
    return 2 * (this.width + this.height);
  }
}
