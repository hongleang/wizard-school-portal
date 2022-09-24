import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { RouterModule, Routes } from '@angular/router';
import { FormsModule  } from '@angular/forms';

import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { TooltipModule } from 'ngx-bootstrap/tooltip';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { AlertModule } from 'ngx-bootstrap/alert';
import { BsDatepickerModule } from 'ngx-bootstrap/datepicker';

import { AppComponent } from './app.component';

import { LoginPageComponent } from './login-page/login-page.component';
import { RegisterPageComponent } from './register-page/register-page.component';
import { HomePageComponent } from './home-page/home-page.component';
import { CardsComponent } from './cards/cards.component';
import { NavbarComponent } from './navbar/navbar.component';
import { HouseDetailsComponent } from './house-details/house-details.component';
import { HttpClientModule } from '@angular/common/http';
import { SuccessfulPageComponent } from './successful-page/successful-page.component';
import { ErrorPageComponent } from './error-page/error-page.component';
import { CharactersCardsComponent } from './characters-cards/characters-cards.component';

const appRoutes: Routes = [
  { path: 'login', component: LoginPageComponent },  
  { path: 'register', component: RegisterPageComponent }, 
  { path: 'home', component: HomePageComponent }, 
  { path: 'house/:houseName', component: HouseDetailsComponent },
  { path: 'success', component: SuccessfulPageComponent},
  { path: '',   redirectTo: '/login', pathMatch: 'full' }, 
  { path: '**', component: ErrorPageComponent}
];

@NgModule({
  declarations: [
    AppComponent,
    RegisterPageComponent,
    LoginPageComponent,
    HomePageComponent,
    CardsComponent,
    NavbarComponent,
    HouseDetailsComponent,
    SuccessfulPageComponent,
    ErrorPageComponent,
    CharactersCardsComponent
  ],
  imports: [
    FormsModule,
    HttpClientModule,
    BrowserModule,
    TooltipModule,
    BrowserAnimationsModule,
    AlertModule.forRoot(),
    BsDropdownModule.forRoot(),
    BsDatepickerModule.forRoot(),
    RouterModule.forRoot(appRoutes)    
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
