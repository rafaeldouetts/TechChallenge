import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { AccountService } from 'src/app/pages/authentication/shared/account.service';

@Component({
  selector: 'app-publicacao',
  templateUrl: './publicacao.component.html',
  styleUrls: ['./publicacao.component.css']
})
export class PublicacaoComponent implements OnInit {


  @Input() descricao:string;
  @Input() url:string;
  @Input() id: number;
  @Input() readonly:boolean;

  @Output() exluir: EventEmitter<number> = new EventEmitter<number>();
  
  nomeUsuario:string = 'Rafael';
  dataPublicacao:Date;
  tempo:string = 'ha duas horas';
  perfil = "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp";

  constructor( private _acountRepository:AccountService,  private _snackBar: MatSnackBar) { }

  ngOnInit() {}


  Excluir()
  {
    debugger
    this._acountRepository.excluirPublicacao(this.id)
    .subscribe(
      data => 
      {
        debugger
        this.exluir.emit(this.id);
        // this._snackBar.open('Publicação excluida com sucesso!');
      },
      err =>
      {
        this._snackBar.open('Náo foi possivel excluir a publicação');
      }
    )
  }
}
