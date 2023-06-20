import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { AccountService } from '../shared/account.service';
import { MatSnackBar } from '@angular/material';
import { Router } from '@angular/router';
import { Title } from '@angular/platform-browser';

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
  
  constructor(private title:Title, private _snackBar: MatSnackBar, private router: Router, private accountService: AccountService) { }

  ngOnInit() {
    this.title.setTitle("Cadastrar");
  }

}
