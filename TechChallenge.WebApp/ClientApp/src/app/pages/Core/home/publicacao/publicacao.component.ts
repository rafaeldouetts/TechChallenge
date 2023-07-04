import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { MatSnackBar } from '@angular/material';
import { AccountService } from 'src/app/pages/Authentication/shared/account.service';


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

  constructor( private _acountRepository:AccountService,  private _snackBar: MatSnackBar) { }

  ngOnInit() {}


  Excluir()
  {
    this._acountRepository.excluirPublicacao(this.id)
    .subscribe(
      data => 
      {
        this.exluir.emit(this.id);
      },
      err =>
      {
        this._snackBar.open('Náo foi possivel excluir a publicação');
      }
    )
  }
}
