import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup} from '@angular/forms';
import { Router } from '@angular/router';
import { localStorageService } from 'src/app/shared/localStorageService';
import { AccountService } from '../shared/account.service';
import { MatDialog, MatSnackBar } from '@angular/material';
import { Title } from '@angular/platform-browser';
import { NovaPublicacaoComponent } from 'src/app/home/nova-publicacao/nova-publicacao/nova-publicacao.component';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form = new FormGroup({
    userName: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(public dialog: MatDialog, private title: Title, private _snackBar: MatSnackBar, private router: Router, private localStorageService: localStorageService, private accountService: AccountService) { }

  ngOnInit() {
    this.title.setTitle("Login");
  }

  adicionar()
  {
    debugger
    this.accountService.logar(this.form.value).subscribe(result => {
      debugger
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

  openDialog(): void {
    const dialogRef = this.dialog.open(NovaPublicacaoComponent, {});

    // dialogRef.afterClosed().subscribe(result => {
    //   console.log('The dialog was closed');
    //   this.animal = result;
    // });
  }
}
