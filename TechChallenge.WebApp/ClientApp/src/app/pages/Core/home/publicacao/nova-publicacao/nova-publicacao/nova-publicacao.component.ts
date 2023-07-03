import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MatSnackBar } from '@angular/material';
import { Foto } from 'src/app/models/Foto';
import { AccountService } from 'src/app/pages/Authentication/shared/account.service';

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

  secondFormGroup = this._formBuilder.group({
    descricao: ['', Validators.required],
  });
  isLinear = false;
  
  constructor(
    private _formBuilder: FormBuilder, 
    private _acountRepository:AccountService, 
    public _dialogRef: MatDialogRef<NovaPublicacaoComponent>,
    private _snackBar: MatSnackBar) { }

  ngOnInit() {}
 
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


  onFileSelected(event: any, stepper) {
    const file:File = event.target.files[0];

        if (file) {
           this._acountRepository.adicionar(file)
           .subscribe(data => 
            {
              this.Foto = data;
              this.Foto.url = data.url + data.extensao
            });

           stepper.next();
        }
  }

  next(stepper){
    this.descricao = this.secondFormGroup.get('descricao').value;
    stepper.next();
  }

  uploadFile()
  {
    const body =  {nome: this.descricao, fotoId: this.Foto.id};

      this._acountRepository.publicar(body)
      .subscribe(data => {
        var imagem = {nome: this.descricao, urlPerfil: this.Foto.url, id: data.id}
        this._dialogRef.close(imagem);
      },
      err => {
        this._snackBar.open('Erro ao realizar publicação!');
      });
  }
}
