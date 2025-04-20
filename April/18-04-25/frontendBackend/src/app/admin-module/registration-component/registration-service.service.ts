import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RegistrationServiceService {

  private apiUrl="https://localhost:7273/api/Form/register"
  private apiUrl2 = "https://localhost:7273/api/Form/all-users"
  constructor(private http:HttpClient) { }

  doRegistration(data: any):Observable<any>{
  
    return this.http.post<any>(this.apiUrl,data)
     
  }
  getregistration():Observable<any>{
    return this.http.get<any>(this.apiUrl2)
  }
}
