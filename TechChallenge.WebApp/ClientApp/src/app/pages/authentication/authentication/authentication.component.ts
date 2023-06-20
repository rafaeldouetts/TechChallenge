import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { localStorageService } from 'src/app/shared/localStorageService';

@Component({
  selector: 'app-authentication',
  templateUrl: './authentication.component.html',
  styleUrls: ['./authentication.component.css']
})
export class AuthenticationComponent implements OnInit {

  constructor(private router: Router, private localStorageService: localStorageService) { }

  ngOnInit() {
  }

  onSubmit(){
    debugger
  }

  adicionar()
  {
    debugger

    //logar no sistema caso der certo colocar o token no cache 

    //e redirecionar para pagina inicial 
    this.localStorageService.setToken('teste');

    this.router.navigate([''])
  }
}
