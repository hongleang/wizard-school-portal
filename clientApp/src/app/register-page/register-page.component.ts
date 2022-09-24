import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { HouseOption } from '../model/House';
import { UserRegisteration } from '../model/User';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register-page',
  templateUrl: './register-page.component.html',
  styleUrls: ['./register-page.component.css']
})
export class RegisterPageComponent implements OnInit {
  model: UserRegisteration = {
    firstName: '',
    lastName: '',
    username: '',
    gender: '',
    password: '',
    species: '',
    houseId: 0,
    dateOfBirth: new Date()
  };

  houses: HouseOption[] = [
    { id: 1, name: 'Gryffindor' },
    { id: 2, name: 'Hufflepuff' },
    { id: 3, name: 'Ravenclaw' },
    { id: 4, name: 'Slytherin' }
  ];

  loading: boolean = false;

  genders: string[] = ['Male', 'Female'];
  species: string[] = ['Human', 'Giant', 'Orc', 'Elve'];

  minDate: Date = new Date();
  maxDate: Date = new Date();

  registerError: boolean = false;
  errorMessage: string = '';

  constructor(private accountService: AccountService, private router: Router) {
    this.minDate.setFullYear(1940);
    this.maxDate.setFullYear(this.maxDate.getFullYear() - 8);
  }

  ngOnInit(): void {
  }

  register() {
    this.loading = true;
    this.accountService.register(this.model).subscribe({
      next: response => {
        if (response) {
          this.loading = false;
          localStorage.setItem('user', JSON.stringify(response));
          this.router.navigate(['/success']);
        }
      },
      error: err => {
        this.loading = false;
        this.registerError = true;
        this.errorMessage = err.error || "Unknown error!";
      }
    });;
  }

  prevenDefault(event: Event) {
    event?.preventDefault();
  }

}
