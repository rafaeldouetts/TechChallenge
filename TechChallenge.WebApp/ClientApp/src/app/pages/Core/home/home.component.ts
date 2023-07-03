import { Component, OnInit } from '@angular/core';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Publicacao } from 'src/app/models/Publicacao';
import { AccountService } from '../../Authentication/shared/account.service';
import { NovaPublicacaoComponent } from './publicacao/nova-publicacao/nova-publicacao/nova-publicacao.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  fileName = '';
  imagens: Publicacao[] = new Array<Publicacao>();

  title = 'angularUpload';
  localUrl: any;
  file?: File;

  constructor(private accountService: AccountService, public dialog: MatDialog, private _snackBar : MatSnackBar) { }
  
  ngOnInit(): void {
    // this.carregar();

    this.accountService.getPublicacoes()
    .subscribe(data => 
      {
        this.imagens = data;
      },
      err => {
        this._snackBar.open("Náo foi possivel carregar as publicaçóes")
      })
  }

  selectFile(event: any) {
    this.file = <File>event.target.files[0];
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.localUrl = event.target.result;
      }
      reader.readAsDataURL(event.target.files[0]);
    }
  }

  uploadFile() {
    if (this.file != undefined) {
      this.accountService.adicionarFoto(this.file).subscribe((data) => {
        console.log(data);
        alert("Arquivo enviado com sucesso!")
      })
    } else {
      alert("Selecione um arquivo!")
    }
  }

  adicionar(event: any) {

    const file: File = event.target.files[0];

    if (file) {

      this.fileName = file.name;

      const formData = new FormData();

      formData.append("thumbnail", file);
    }
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NovaPublicacaoComponent, {});

    dialogRef.afterClosed().subscribe(result => {

      if(result)
        this.imagens.push(result);
    });
  }

  excluirPublicacao(id)
  {
    var index = this.imagens.findIndex(x => x.id == id);

    if(index == -1) return;

    this.imagens.splice(index, 1);
  }
}


