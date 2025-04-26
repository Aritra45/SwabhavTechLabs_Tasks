import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyServiceService {

  constructor(private http: HttpClient) { }

  //inbound
  private apiUrl1 = "http://localhost:5147/api/InBoundBeneficiary/all-inbound-beneficiaries"
  private apiUrl3 = "http://localhost:5147/api/InBoundBeneficiary/add-inbound-beneficiaries"

  //company
  private apiUrl2 = "http://localhost:5147/api/Company/all-companies"
  
  //outbound
  private apiUrl4 = "http://localhost:5147/api/OutBoundBeneficiary/all-oubound-beneficiaries"
  private apiUrl5 = "http://localhost:5147/api/OutBoundBeneficiary/add-outbound-beneficiaries"

  //transaction
  private apiUrl6 = "http://localhost:5147/api/Transaction/add-new-transaction"

  //inbound
  getInBoundBeneficiary(): Observable<any> {
    return this.http.get<any>(this.apiUrl1)
  }

  AddInBound(data: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl3, data, { headers, responseType: 'text' });
  }

  //company
  getAllCompany(): Observable<any> {
    return this.http.get<any>(this.apiUrl2)
  }

  //outbound
  getOutBoundBeneficiary(): Observable<any> {
    return this.http.get<any>(this.apiUrl4)
  }
  
  AddOutBound(data: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl5, data, { headers, responseType: 'text' });
  }

  //transaction
  AddTransaction(data: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl6, data, { headers, responseType: 'text' });
  }
}
