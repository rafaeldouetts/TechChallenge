import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Foto } from 'src/app/models/Foto';
import { ResponseModel, ResponseTokenModel } from 'src/app/models/Login';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  // baseUrl = environment.baseUrl;

  baseUrl = "";
  minimalUrl = "";

  // minimalUrl = environment.minimalUrl;
  // coreUrl = environment.baseCoreUrl;
  coreUrl = "";

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  httpOptionsImage = {
    headers: new HttpHeaders({ 'Content-Type': 'multipart/form-data; boundary=something' })
  };

  constructor(private http: HttpClient) { }

  logar(formData) : Observable<ResponseTokenModel>
  {
    return this.http.post<ResponseTokenModel>(`${this.baseUrl}/api/Authenticate/login`, formData, this.httpOptions);
  }

  Cadastrar(formData): Observable<ResponseModel>
  {
    return this.http.post<ResponseModel>(`${this.baseUrl}/api/Authenticate/register`, formData, this.httpOptions);
  }

  adicionarFoto(file:File) :  Observable<any> 
  {
    const form: FormData = new FormData();
    
    form.append('formFile', file);

    return this.http.post<any>(`${this.minimalUrl}/Upload`, form, this.httpOptionsImage);
  }

  adicionar(file:File) : Observable<Foto>
  {
    const form: FormData = new FormData();
    console.log(file.name);
    console.log(file);
    form.append('formFile', file);

    return this.http.post<any>(`${this.coreUrl}/Foto`, form);
  }

  publicar(body:any) : Observable<any>
  {
    return this.http.post<any>(`${this.coreUrl}/publi/new`, body);
  }

  getPublicacoes(): Observable<any>
  {
    return this.http.get<any>(`${this.coreUrl}/publi`);
  }

  excluirPublicacao(publicacaoId:number): Observable<any>
  {
    return this.http.delete<any>(`${this.coreUrl}/publi/${publicacaoId}`);
  }

}
