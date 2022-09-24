import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-login-page',
  templateUrl: './login-page.component.html',
  styleUrls: ['./login-page.component.css']
})
export class LoginPageComponent implements OnInit {
  model: any = {};
  loggedInError: boolean = false;
  errorMessage: string = '';

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit(): void {
  }

  login() {
    this.loggedInError = false;
    this.accountService.login(this.model).subscribe({
      next: response => {
        if(response){
          this.router.navigate(['/home']);
        }
      },
      error: err => {
        this.loggedInError = true;
        this.errorMessage = err.error || "Unknown error!";
      }
    });
  }

}
