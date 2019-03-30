import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Phone } from '../models/phone';

@Injectable({
  providedIn: 'root'
})
export class PhonesService {
  url = 'http://localhost:60224/Phones';
  httpOptions = { headers: new HttpHeaders({ 'Content-Type': 'application/json'}) };

  constructor(private http: HttpClient) { }

  getAllPhones(): Observable<Phone[]> {
    return this.http.get<Phone[]>(this.url + '/PersonPhones');
  }

  getPhoneById(PhoneId: string): Observable<Phone> {
    return this.http.get<Phone>(this.url + '/GetPhoneById/' + PhoneId);
  }

  createPhone(phone: Phone): Observable<Phone> {
    return this.http.post<Phone>(this.url + '/CreatePhone/', phone, this.httpOptions);
  }

  updatePhone(phone: Phone): Observable<Phone> {
    return this.http.put<Phone>(this.url + '/UpdatePhone/', phone, this.httpOptions);
  }

  deletePhoneById(PhoneId: string): Observable<number> {
    return this.http.delete<number>(this.url + '/DeletePhone/' + PhoneId, this.httpOptions);
  }
}
