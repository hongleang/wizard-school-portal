import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';
import { QueryServiceService } from '../_services/query-service.service';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {
  houses: any;
  user: any;

  constructor(private accountService: AccountService, private queryService: QueryServiceService) {
    this.getHouses();
    this.user = JSON.parse(localStorage.getItem('user') ?? "") ?? null;
  }
  ngOnInit(): void {
    this.accountService.authenticated();
  }

  getHouses() {
    return this.queryService.getHouses().subscribe({
      next: response => {
        if (response) {
          this.houses = response ?? null;
        }
      },
      error: err => console.log(err)
    });
  }

}
