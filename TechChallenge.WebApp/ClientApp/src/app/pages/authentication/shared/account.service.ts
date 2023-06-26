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
  minimalUrl = environment.minimalUrl;

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  httpOptionsImage = {
    headers: new HttpHeaders({ 'Content-Disposition': 'multipart/form-data' })
  };

  // headers =
  // {
  //   headers:new HttpHeaders(' Content-Disposition ', 'multipart/form-data')

  // } 
  
  constructor(private http: HttpClient) { }

  logar(formData)
  {
    return this.http.post<ResponseModel>(`${this.baseUrl}/api/Authenticate/login`, formData, this.httpOptions);
  }

  Cadastrar(formData): Observable<ResponseModel>
  {
    return this.http.post<ResponseModel>(`${this.baseUrl}/api/Authenticate/register`, formData, this.httpOptions);
  }

  adicionarFoto(file:File) :  Observable<any> 
  {
    const form: FormData = new FormData();
    console.log(file.name);
    console.log(file);
    form.append('formFile', file);

   

    return this.http.post<any>(`${this.minimalUrl}/Upload`, form, this.httpOptionsImage);
  }
}
