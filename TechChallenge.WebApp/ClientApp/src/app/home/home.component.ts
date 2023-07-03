import { Component, OnInit } from '@angular/core';
import { ImagemRepository } from './ImagemRepository';
import { Foto, Publicacao} from './model/Imagem';
import { AccountService } from '../pages/authentication/shared/account.service';
import { MatDialog, MatSnackBar } from '@angular/material';
import { NovaPublicacaoComponent } from './nova-publicacao/nova-publicacao/nova-publicacao.component';

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
        debugger

        this.imagens = data;
      },
      err => {
        debugger
        this._snackBar.open("Náo foi possivel carregar as publicaçóes")
      })
  }

  selectFile(event: any) {
    debugger
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
    debugger
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
    debugger

    const file: File = event.target.files[0];

    if (file) {

      this.fileName = file.name;

      const formData = new FormData();

      formData.append("thumbnail", file);

      // this.accountService.adicionarFoto(formData).subscribe(data => {
      //   debugger
      //   //imagem adicionada com sucesso 
      // },
      //   err => {
      //     debugger
      //     //imagem náo adicionada com sucesso 
      //   }
      // );
    }
  }


  carregar(){


    var publica = new Foto("https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", true, new Date());
        var privada = new Foto("https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", false, new Date());

        var lista = [new Publicacao("imagem 1", "Douglas", "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", publica), 
        new Publicacao("imagem 2", "Camila", "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", privada), 
        new Publicacao("imagem 3", "Maria", "https://img.freepik.com/vetores-premium/homem-perfil-caricatura_18591-58482.jpg", privada)]


        for(var i = 0; i < 10; i++)
        {
          lista.push(new Publicacao("imagem 1", "Douglas", "https://www.wikihow.com/images_en/thumb/d/db/Get-the-URL-for-Pictures-Step-2-Version-6.jpg/v4-460px-Get-the-URL-for-Pictures-Step-2-Version-6.jpg.webp", publica))
        }


        this.imagens = lista;
  }

  buscar(){
    //realizar consulta de imagens
  }

  openDialog(): void {
    const dialogRef = this.dialog.open(NovaPublicacaoComponent, {});

    dialogRef.afterClosed().subscribe(result => {
      debugger

      if(result)
        this.imagens.push(result);
    });
  }

  excluirPublicacao(id)
  {
    debugger
    var index = this.imagens.findIndex(x => x.id == id);

    if(index == -1) return;

    this.imagens.splice(index, 1);
  }
}


