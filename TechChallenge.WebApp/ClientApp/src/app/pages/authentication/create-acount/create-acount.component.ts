import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../shared/account.service';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';

@Component({
  selector: 'app-create-acount',
  templateUrl: './create-acount.component.html',
  styleUrls: ['./create-acount.component.css']
})
export class CreateAcountComponent implements OnInit {

  form = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl(''),
    email: new FormControl('')
  });
  
  constructor(private _snackBar: MatSnackBar, private router: Router, private accountService: AccountService) { }

  ngOnInit() {
  }

  adicionar()
  {
    this.accountService.Cadastrar(this.form.value).subscribe(result => {
      debugger
      this._snackBar.open('Usuario Cadastrado com sucesso!');

      this.router.navigate([''])
    },
    err =>{
      this._snackBar.open('Usuario ou senha invalida');
    });
  }

}
