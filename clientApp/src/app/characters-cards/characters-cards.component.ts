import { Component, Input, OnInit } from '@angular/core';
import { Characters } from '../model/House';

@Component({
  selector: 'app-characters-cards',
  templateUrl: './characters-cards.component.html',
  styleUrls: ['./characters-cards.component.css']
})
export class CharactersCardsComponent implements OnInit {
  @Input() characters: Characters[] = [];

  constructor() { }

  ngOnInit(): void { }

}
