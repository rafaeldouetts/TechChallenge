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

  title = 'angularUpload';
  localUrl: any;
  file?: File;

  constructor(private accountService: AccountService) { }
  
  ngOnInit(): void {
    this.carregar();
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
    this.getUsuario();

    // var result = this.homeRepository.carregar();

    // this.imagens = result;

    debugger
  }

  buscar(){
    //realizar consulta de imagens
  }
}


