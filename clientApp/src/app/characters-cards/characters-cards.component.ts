import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-characters-cards',
  templateUrl: './characters-cards.component.html',
  styleUrls: ['./characters-cards.component.css']
})
export class CharactersCardsComponent implements OnInit {
  @Input() characters: any;

  constructor() { }

  ngOnInit(): void { }

  characterImage(id: number) {
    return this.characters[id].imageUrl;
  }

}
