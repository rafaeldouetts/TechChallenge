import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ResponseModel } from 'src/app/models/Login';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl = environment.baseUrl;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };
  
  constructor(private http: HttpClient) { }

  logar(formData): Observable<ResponseModel>
  {
    return this.http.post<ResponseModel>(`${this.baseUrl}/api/Authenticate/login`, formData, this.httpOptions);
  }

  Cadastrar(formData): Observable<ResponseModel>
  {
    return this.http.post<ResponseModel>(`${this.baseUrl}/api/Authenticate/register`, formData, this.httpOptions);
  }

  BuscarUsuario() : Observable<any>
  {
    return this.http.get<any>(`${this.baseUrl}/api/Authenticate/authenticated`, this.httpOptions);
  }
}
