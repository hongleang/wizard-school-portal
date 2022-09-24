import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Location } from '@angular/common';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-error-page',
  templateUrl: './error-page.component.html',
  styleUrls: ['./error-page.component.css']
})
export class ErrorPageComponent implements OnInit {

  constructor(private accountService: AccountService, private location: Location, private router: Router) {
  }
  ngOnInit(): void {
  }

  onClick() {
    if (!this.accountService.loggedIn()) {
      this.router.navigate(['/login'])
    } else {
      this.location.back();
    }
  }

}
