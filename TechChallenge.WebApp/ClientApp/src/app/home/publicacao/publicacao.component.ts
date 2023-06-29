import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-publicacao',
  templateUrl: './publicacao.component.html',
  styleUrls: ['./publicacao.component.css']
})
export class PublicacaoComponent implements OnInit {


  @Input() descricao:string;
  @Input() url:string;
  
  nomeUsuario:string = 'Rafael';
  dataPublicacao:Date;
  tempo:string = 'ha duas horas';
  perfil = "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp";

  constructor() { }

  ngOnInit() {}

}
