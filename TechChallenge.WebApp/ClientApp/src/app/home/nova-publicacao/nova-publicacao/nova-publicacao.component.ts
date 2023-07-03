import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ImagemRepository } from '../../ImagemRepository';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { AccountService } from 'src/app/pages/authentication/shared/account.service';
import { Foto } from '../../model/Imagem';

@Component({
  selector: 'app-nova-publicacao',
  templateUrl: './nova-publicacao.component.html',
  styleUrls: ['./nova-publicacao.component.css']
})
export class NovaPublicacaoComponent implements OnInit {

  localUrl: any;
  file?: File;
  form: FormArray;
  fileName:any;
  descricao:string;
  checkedPublico:boolean = true;

  formGroup = new FormGroup({
    descricao: new FormControl('')
  });

  Foto:Foto = new Foto();

  // firstFormGroup = this._formBuilder.group({
  //   firstCtrl: ['', Validators.required],
  // });
  secondFormGroup = this._formBuilder.group({
    descricao: ['', Validators.required],
  });
  isLinear = false;
  
  constructor(
    private _formBuilder: FormBuilder, 
    private _imagemRepository:ImagemRepository,   
    private _acountRepository:AccountService, 
    public _dialogRef: MatDialogRef<NovaPublicacaoComponent>,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {}
 
  selectFile(event: any) {
    debugger

    var arquivo = document.getElementById('selecao-arquivo');

    this.file = <File>event.target.files[0];
    if (event.target.files && event.target.files[0]) {
      var reader = new FileReader();
      reader.onload = (event: any) => {
        this.localUrl = event.target.result;
      }
      reader.readAsDataURL(event.target.files[0]);
    }
  }


  onFileSelected(event: any, stepper) {
    debugger

    const file:File = event.target.files[0];

        if (file) {

            // this.fileName = file.name;

            // const formData = new FormData();

            // formData.append("thumbnail", file);

           this._acountRepository.adicionar(file)
           .subscribe(data => 
            {
              debugger
              this.Foto = data;
              this.Foto.url = data.url + data.extensao
            });

           stepper.next();
            // const upload$ = this.http.post("/api/thumbnail-upload", formData);

            // upload$.subscribe();
        }
  }

  next(stepper){
    this.descricao = this.secondFormGroup.get('descricao').value;
    stepper.next();
  }

  uploadFile()
  {
      debugger
    const body =  {nome: this.descricao, fotoId: this.Foto.id};

      this._acountRepository.publicar(body)
      .subscribe(data => {
        debugger

        var imagem = {nome: this.descricao, urlPerfil: this.Foto.url, id: data.id}
        this._dialogRef.close(imagem);
      },
      err => {
        this._snackBar.open('Erro ao realizar publicação!');
      });
  }
}
