import { Component, Input, OnInit } from '@angular/core';
import { UserDetails } from '../model/User';
import { QueryServiceService } from '../_services/query-service.service';

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.css']
})
export class CardsComponent implements OnInit {
  @Input() houses: any = [];
  @Input() user: any;

  userDetails: any;

  constructor(private queryService: QueryServiceService) { }

  ngOnInit(): void {
  }
}
