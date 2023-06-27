import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Observable } from "rxjs";
import { foto, publicacao } from "./model/Imagem";
import { environment } from "src/environments/environment";

export class ImagemRepository {
 
    //  constructor(private http: HttpClient) { }

    baseUrl = environment.baseUrl;
    
    httpOptions = {
      headers: new HttpHeaders({ 'Content-Type': 'application/json' })
    };

    // adicionar(formData) : Observable<string>
    // {
        // return this.http.post<any>(`${this.baseUrl}/Foto`, formData, this.httpOptions);
    
        // return "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp";
    // }

    // carregar(): Observable<imagem>
    // {
        
    // }

    carregar(): publicacao[]
    {
        var publica = new foto("https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", true, new Date());
        var privada = new foto("https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", false, new Date());

        var lista = [new publicacao("imagem 1", "Douglas", "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", publica), 
        new publicacao("imagem 2", "Camila", "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", privada), 
        new publicacao("imagem 3", "Maria", "https://img.freepik.com/vetores-premium/homem-perfil-caricatura_18591-58482.jpg", privada)]
        return lista;
    }
}