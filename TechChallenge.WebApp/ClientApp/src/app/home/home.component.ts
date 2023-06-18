import { Component, OnInit } from '@angular/core';
import { ImagemRepository } from './ImagemRepository';
import { publicacao } from './model/Imagem';
import { AccountService } from '../pages/authentication/shared/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  fileName = '';
  imagens: publicacao[];

  constructor(private homeRepository: ImagemRepository, private accountService: AccountService) { }
  
  ngOnInit(): void {
    this.carregar();
  }


  adicionar(event: any) {
    debugger

    const file: File = event.target.files[0];

    if (file) {

      this.fileName = file.name;

      const formData = new FormData();

      formData.append("thumbnail", file);

      this.homeRepository.adicionar(formData).subscribe(data => {

        //imagem adicionada com sucesso 
      },
        err => {
          //imagem náo adicionada com sucesso 
        }
      );
    }
  }

  getUsuario()
  {
    this.accountService.BuscarUsuario()
    .subscribe(result => {
      debugger
    },
    err => {
      debugger
    })
  }


  carregar(){
    this.getUsuario();

    var result = this.homeRepository.carregar();

    this.imagens = result;

    debugger
  }

  buscar(){
    //realizar consulta de imagens
  }
}


