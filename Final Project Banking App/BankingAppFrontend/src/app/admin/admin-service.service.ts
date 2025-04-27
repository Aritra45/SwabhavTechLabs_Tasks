import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdminServiceService {
  //admin-controller
  private apiUrl1 = "http://localhost:5147/api/User/add-admin";
  private apiUrl2 = "http://localhost:5147/api/User/all-admins"
  private apiUrl3 = "http://localhost:5147/api/User/remove-admin-access"

  //bank-controller
  private apiUrl4 = "http://localhost:5147/api/User/all-banks";
  private apiUrl5 = "http://localhost:5147/api/User/add-new-bank";
  private apiUrl6 = "http://localhost:5147/api/User/remove-bank-access";
  private apiUrl7 = "http://localhost:5147/api/User/get-by-bank-email"
  private apiUrl8 = "http://localhost:5147/api/User/update-bank-password"

  //company-controller
  private apiUrl9 = "http://localhost:5147/api/User/update-pending-companies"
  private apiUrl10 = "http://localhost:5147/api/User/all-pending-companies"

  //transaction-controller
  private apiUrl11 = "http://localhost:5147/api/User/all-pending-transactions"
  private apiUrl12 = "http://localhost:5147/api/User/update-pending-transactions"

  //beneficiary-controller
  private apiUrl13 = "http://localhost:5147/api/User/all-oubound-pending-beneficiaries"
  private apiUrl14 = "http://localhost:5147/api/User/update-pending-beneficiaries"

  //auditlog-controller
  private apiUrl15 = "http://localhost:5147/api/User/all-logs"
  private apiUrl16 = "http://localhost:5147/api/User/by-user"
  private apiUrl17 = "http://localhost:5147/api/User/by-date"

  //employee
  private apiUrl18 = "http://localhost:5147/api/User/all-pending-salary"
  private apiUrl19 = "http://localhost:5147/api/User/update-pending-salary"

  constructor(private http: HttpClient) { }

    //admin
  doRegistration(data: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl1, data, { headers, responseType: 'text' });
  }

  getregistration():Observable<any>{
    return this.http.get<any>(this.apiUrl2)
  }

  removeAdminAccess(userEmail: any): Observable<string> {
    return this.http.delete<string>(`${this.apiUrl3}/${encodeURIComponent(userEmail)}`, { responseType: 'text' as 'json' });
  }

  //banks
  getbanks():Observable<any>{
    return this.http.get<any>(this.apiUrl4)
  }

  doBankRegistration(data: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.post(this.apiUrl5, data, { headers, responseType: 'text' });
  }

  removeBankAccess(bankEmail: any): Observable<string> {
    return this.http.delete<string>(`${this.apiUrl6}/${encodeURIComponent(bankEmail)}`, { responseType: 'text' as 'json' });
  }

  getBankByEmail(bankEmail: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(`${this.apiUrl7}/${encodeURIComponent(bankEmail)}`, { headers });
  }

  updateBankPassword(bankEmail: string, data: Record<string, any>): Observable<any> {
    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No authentication token found.');
    }
  
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  
    const url = `${this.apiUrl8}/${encodeURIComponent(bankEmail)}`;
    return this.http.put<any>(url, data,{ responseType: 'text' as 'json' });
  }
  
  //company
  updatependingCompany(companyEmail: string, data:any): Observable<any> {

    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No authentication token found.');
    }
  
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  
    const url = `${this.apiUrl9}/${encodeURIComponent(companyEmail)}`;
  
    return this.http.put<any>(url,data , { headers, responseType: 'text' as 'json' });
  }
  

  getPendingCompanies():Observable<any>{
    return this.http.get<any>(this.apiUrl10)
  }

  //transaction
  getPendingCompaniesTransaction():Observable<any>{
    return this.http.get<any>(this.apiUrl11)
  }

  updatependingCompanyTransaction(transactionID: number, data:any): Observable<any> {

    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No authentication token found.');
    }
  
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  
    const url = `${this.apiUrl12}/${transactionID}`;
  
    return this.http.put<any>(url,data , { headers, responseType: 'text' as 'json' });
  }

  //beneficiary
  getPendingBeneficiaries():Observable<any>{
    return this.http.get<any>(this.apiUrl13)
  }

  updatependingBeneficiaries(beneficiaryEmail: string, data:any): Observable<any> {

    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No authentication token found.');
    }
  
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  
    const url = `${this.apiUrl14}/${encodeURIComponent(beneficiaryEmail)}`;
  
    return this.http.put<any>(url,data , { headers, responseType: 'text' as 'json' });
  }

  //audit
  getAllAudit():Observable<any>{
    return this.http.get<any>(this.apiUrl15)
  }

  getAuditByUserId(auditId: any): Observable<any> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any>(`${this.apiUrl16}/${auditId}`, { headers });
  }

  getAuditByDate(date: string): Observable<any[]> {
    const token = localStorage.getItem('token');
    const headers = new HttpHeaders().set('Authorization', `Bearer ${token}`);
    return this.http.get<any[]>(`${this.apiUrl17}?date=${date}`, { headers });
  }
  
  //employee
  getPendingSalary():Observable<any>{
    return this.http.get<any>(this.apiUrl18)
  }

  updatePendingSalary(transactionID: number, data:any): Observable<any> {

    const token = localStorage.getItem('token');
    if (!token) {
      throw new Error('No authentication token found.');
    }
  
    const headers = new HttpHeaders({
      'Authorization': `Bearer ${token}`,
      'Content-Type': 'application/json'
    });
  
    const url = `${this.apiUrl19}/${transactionID}`;
  
    return this.http.put<any>(url,data , { headers, responseType: 'text' as 'json' });
  }
   
}
