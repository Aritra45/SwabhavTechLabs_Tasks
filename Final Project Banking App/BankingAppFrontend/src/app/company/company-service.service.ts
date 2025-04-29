import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CompanyServiceService {

  constructor(private http: HttpClient) { }

  //inbound
  private apiUrl1 = "http://localhost:5147/api/Company/all-inbound-beneficiaries"
  private apiUrl3 = "http://localhost:5147/api/Company/add-inbound-beneficiaries"

  //company
  private apiUrl2 = "http://localhost:5147/api/Company/all-companies"
  private apiUrl10 = "http://localhost:5147/api/Company/all-approved-companies"
  
  //outbound
  private apiUrl4 = "http://localhost:5147/api/Company/all-oubound-beneficiaries"
  private apiUrl5 = "http://localhost:5147/api/Company/add-outbound-beneficiaries"

  //transaction
  private apiUrl6 = "http://localhost:5147/api/Company/add-new-transaction"

  //employee
  private apiUrl7 = "http://localhost:5147/api/Company/all-employees"
  private apiUrl8 = "http://localhost:5147/api/Company/upload-csv"
  private apiUrl9 = "http://localhost:5147/api/Company/bulk-salary-disbursement"

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
  getApprovedCompany(): Observable<any> {
    return this.http.get<any>(this.apiUrl10)
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

  //employee
  getEmployee(): Observable<any> {
    return this.http.get<any>(this.apiUrl7)
  }

  AddEmployee(formData: FormData): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl8, formData, { headers });
  }

  addSalaryEmployee(employees: any, headers: HttpHeaders): Observable<any> {
    return this.http.post(this.apiUrl9, employees, { headers });
  }
  
  
  
}
