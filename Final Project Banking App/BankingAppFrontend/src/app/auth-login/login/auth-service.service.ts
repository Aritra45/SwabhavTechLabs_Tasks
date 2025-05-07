import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  private apiUrl = "http://localhost:5147/api/Auth";

  constructor(private http: HttpClient) {}

  login1(userEmail: string, password: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/login`, { userEmail, password });
  }

  logout(email: string): Observable<any> {
    return this.http.post(`${this.apiUrl}/logout`, {email}, { responseType: 'text' as 'json' });
  }
}
