import { Component } from '@angular/core';
import { localStorageService } from 'src/app/shared/localStorageService';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent {
  isExpanded = false;

  constructor(private _localStorageService: localStorageService){

  }

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

Sair()
{
  this._localStorageService.removerToken();
  window.location.reload();
}

}
