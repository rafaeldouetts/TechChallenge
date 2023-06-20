import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

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

  logar()
  {
      //  return this.http.post("/api/thumbnail-upload", formData);
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
