import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';


@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private accountService: AccountService) { }

  ngOnInit(): void {    
  }

  logout() {
    this.accountService.logout();
  }

  getCurrentUserName() {
    const user = JSON.parse(localStorage.getItem('user') ?? "");
    return user.username;
  }

}
