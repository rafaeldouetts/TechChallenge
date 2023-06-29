export class publicacao {
    constructor(nome:string, usuario:string, urlPerfil:string, foto:foto)
    {
        this.nome = nome;
        this.usuario = usuario;
        this.urlPerfil = urlPerfil;
        this.foto = foto;
    }
    nome:string;
    usuario:string;
    foto:foto;
    urlPerfil:string;
}

export class foto {

    constructor(url:string = null, publica:boolean = null, dataEnvio:Date = null)
{
    this.url = url;
    this.publica = publica;
    this.dataEnvio = dataEnvio;
}
    url:string;
    publica:boolean;
    dataEnvio:Date;
}