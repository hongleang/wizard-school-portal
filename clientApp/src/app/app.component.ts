import { Component } from '@angular/core';
import { User } from './model/User';
import { AccountService } from './_services/account.service';

import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'school-portal';

  constructor(private accountService: AccountService, private router: Router) { }

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user') ?? "{}");
    this.accountService.setCurrentUesr(user);
  }
}
