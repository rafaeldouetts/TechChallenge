import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule, MatCardModule, MatDialogModule, MatFormFieldModule, MatIconModule, MatInputModule, MatSlideToggleModule, MatSnackBarModule, MatStepperModule } from '@angular/material';

import { localStorageService } from './shared/localStorageService';
import { NavMenuComponent } from './pages/Components/nav-menu/nav-menu.component';
import { HomeComponent } from './pages/Core/home/home.component';
import { AuthenticationComponent } from './pages/Authentication/authentication/authentication.component';
import { LoginComponent } from './pages/Authentication/login/login.component';
import { NovaPublicacaoComponent } from './pages/Core/home/publicacao/nova-publicacao/nova-publicacao/nova-publicacao.component';
import { CreateAcountComponent } from './pages/Authentication/create-acount/create-acount.component';
import { PublicacaoComponent } from './pages/Core/home/publicacao/publicacao.component';
import { AuthGuard } from './pages/Authentication/shared/auth.guard';
import { ErrorRequestInterceptor } from './pages/Authentication/shared/Error.Interceptor';
import { TokenInterceptor } from './pages/Authentication/shared/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AuthenticationComponent,
    LoginComponent,
    NovaPublicacaoComponent,
    CreateAcountComponent,
    PublicacaoComponent
  ],
  entryComponents:[NovaPublicacaoComponent],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatStepperModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', children:[
    ],
    canActivate:[AuthGuard]

  },

    {path: '', component: AuthenticationComponent},
    {path: '', redirectTo:'login', pathMatch: 'full'},
    {path: 'login', component: LoginComponent },
    { path: 'create-account', component: CreateAcountComponent },
      
    ]),
    BrowserAnimationsModule,
    ReactiveFormsModule,
    MatSnackBarModule,
    ErrorRequestInterceptor,
    TokenInterceptor,
    BrowserAnimationsModule,
    MatFormFieldModule,
    MatInputModule,
    MatDialogModule,
    MatSlideToggleModule

  ],
  providers: [localStorageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
