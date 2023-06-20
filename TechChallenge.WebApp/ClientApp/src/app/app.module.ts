import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { FetchDataComponent } from './fetch-data/fetch-data.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatIconModule } from '@angular/material';
import { ImagemRepository } from './home/ImagemRepository';
import { LoginComponent } from './pages/authentication/login/login.component';
import { CreateAcountComponent } from './pages/authentication/create-acount/create-acount.component';
import { AuthenticationComponent } from './pages/authentication/authentication/authentication.component';
import { AuthGuard } from './pages/authentication/shared/auth.guard';
import { localStorageService } from './shared/localStorageService';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    FetchDataComponent,
    AuthenticationComponent,
    LoginComponent,
    CreateAcountComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', children:[
      { path: 'counter', component: CounterComponent },
      { path: 'fetch-data', component: FetchDataComponent}
    ],
    canActivate:[AuthGuard]

  },

    {
      path: '', 
      component: AuthenticationComponent,
      children:[
        {path: '', redirectTo:'login', pathMatch: 'full'},
        { path: 'login', component: LoginComponent },
        { path: 'create-account', component: CreateAcountComponent },
      ]
    }
      
    ]),
    BrowserAnimationsModule
  ],
  providers: [localStorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
