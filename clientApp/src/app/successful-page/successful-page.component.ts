import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-successful-page',
  templateUrl: './successful-page.component.html',
  styleUrls: ['./successful-page.component.css']
})
export class SuccessfulPageComponent implements OnInit {

  constructor(private router : Router) { }

  ngOnInit(): void {
  }

  onClick(){
    this.router.navigate(['/home']);
  }

}
