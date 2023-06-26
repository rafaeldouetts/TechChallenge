import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ImagemRepository } from '../../ImagemRepository';
import { MatDialogRef } from '@angular/material';
import { foto, publicacao } from '../../model/Imagem';

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


  // firstFormGroup = this._formBuilder.group({
  //   firstCtrl: ['', Validators.required],
  // });
  secondFormGroup = this._formBuilder.group({
    descricao: ['', Validators.required],
  });
  isLinear = false;
  
  constructor(private _formBuilder: FormBuilder, private imagemRepository:ImagemRepository,   public _dialogRef: MatDialogRef<NovaPublicacaoComponent>) { }

  ngOnInit() {
    // this.formGroup = this._formBuilder.group({
    //   form : this._formBuilder.array([this.init2()])
    // });
  }
  // addItem() {
  //   this.form = this.formGroup.get('form') as FormArray;
  //   this.form.push(this.init2());
  // }

  // init2() {
  //   return this._formBuilder.group({
  //     descricao: new FormControl('', [Validators.required]),
  //       });
  // }

  selectFile(event: any) {
    debugger

    var teste = document.getElementById('selecao-arquivo');

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

            this.fileName = file.name;

            const formData = new FormData();

            formData.append("thumbnail", file);

           this.localUrl = this.imagemRepository.adicionar('');

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
    this.descricao;
    this.localUrl;

    // this.imagemRepository.adicionar()

      debugger

      var teste = new publicacao(this.descricao, '', this.localUrl, new foto());
    this._dialogRef.close(teste);
  }
}
