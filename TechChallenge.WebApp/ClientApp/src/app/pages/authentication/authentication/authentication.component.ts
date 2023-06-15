import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { localStorageService } from 'src/app/shared/localStorageService';
import { AccountService } from '../shared/account.service';
import { MatSnackBar } from '@angular/material';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent implements OnInit {

  form = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(private _snackBar: MatSnackBar, private router: Router, private localStorageService: localStorageService, private accountService: AccountService) { }

  ngOnInit() {
  }

  adicionar()
  {
    this.accountService.logar(this.form.value).subscribe(result => {
      this.localStorageService.setToken(result.data);
      this.router.navigate([''])
    },
    err =>{
      this._snackBar.open('Usuario ou senha invalida');
    });
  }

  cadastrar()
  {
    this.router.navigate(['create-account']);
  }
}
