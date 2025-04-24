import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BankServiceService {

  constructor(private http: HttpClient) { }

  private apiUrl1 = "http://localhost:5147/api/Transaction/all-transactions"

  getTransactions():Observable<any>{
      return this.http.get<any>(this.apiUrl1)
    }
}
