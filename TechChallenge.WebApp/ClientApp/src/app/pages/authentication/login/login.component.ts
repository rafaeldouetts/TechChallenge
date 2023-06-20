import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { localStorageService } from 'src/app/shared/localStorageService';
import { AccountService } from '../shared/account.service';
import { MatSnackBar } from '@angular/material';
import { Title } from '@angular/platform-browser';
@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor() { }

  constructor(private title: Title, private _snackBar: MatSnackBar, private router: Router, private localStorageService: localStorageService, private accountService: AccountService) { }

  ngOnInit() {
    this.title.setTitle("Login");
  }

}
