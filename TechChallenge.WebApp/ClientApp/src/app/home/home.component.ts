import { Component, OnInit } from '@angular/core';
import { ImagemRepository } from './ImagemRepository';
import { publicacao } from './model/Imagem';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  fileName = '';
  imagens: publicacao[];

  constructor(private homeRepository: ImagemRepository) { }
  
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


  carregar(){
    var result = this.homeRepository.carregar();

    this.imagens = result;

    debugger
  }

  buscar(){
    //realizar consulta de imagens
  }
}


