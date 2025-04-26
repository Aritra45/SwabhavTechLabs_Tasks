import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthServiceService {

  private apiUrl1 = "http://localhost:5147/api/Company/register";
  private apiUrl2 = "http://localhost:5147/api/Company/verify-otp";

  constructor(private http: HttpClient) {}

  doRegistration(data: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl1, data, { headers, responseType: 'text' });
  }

  doVerify(data: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl2, data, { headers, responseType: 'text' });
  }
}
