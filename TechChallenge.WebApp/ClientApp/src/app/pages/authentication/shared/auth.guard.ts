import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { localStorageService } from 'src/app/shared/localStorageService';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  
  constructor(private router: Router, 
    private localStorage: localStorageService){

  }
  
  
  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): boolean 
    {
     const token = this.localStorage.getToken();
     const dataAgora = new Date();
     
     if(token) {
        const dataExpiracao = new Date(token.validTo);

        if(token && dataAgora.getTime() < dataExpiracao.getTime()) return true;
      } 
      else  
        this.router.navigate(['login']);
  }
  
}
