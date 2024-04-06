import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environment'

@Injectable({
  providedIn: 'root',
})
export class RectangleService {
  private apiUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getDimensions(): Observable<any> {
    return this.http.get(this.apiUrl);
  }

  updateDimensions(dimensions: any): Observable<any> {
    return this.http.put(this.apiUrl, dimensions);
  }
}
