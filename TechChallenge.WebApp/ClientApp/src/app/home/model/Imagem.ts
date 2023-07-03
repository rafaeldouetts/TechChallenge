export class Publicacao {
    constructor(nome:string, usuario:string, urlPerfil:string, foto:Foto)
    {
        this.nome = nome;
        this.usuario = usuario;
        this.urlPerfil = urlPerfil;
        this.foto = foto;
    }
    nome:string;
    usuario:string;
    foto:Foto;
    urlPerfil:string;
    id:number
}

export class Foto {

    constructor(url:string = null, publica:boolean = null, dataEnvio:Date = null)
{
    this.url = url;
    this.publica = publica;
    this.dataEnvio = dataEnvio;
}
    url:string;
    publica:boolean;
    dataEnvio:Date;
    id:string;
    extensao:string;
}