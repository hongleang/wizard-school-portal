import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { QueryServiceService } from '../_services/query-service.service';

@Component({
  selector: 'app-house-details',
  templateUrl: './house-details.component.html',
  styleUrls: ['./house-details.component.css']
})
export class HouseDetailsComponent implements OnInit {
  houseName: string = '';
  house: any;

  characters: any;

  constructor(private queryService: QueryServiceService, private route: ActivatedRoute) {
    route.params.subscribe((params) => {
      this.houseName = params["houseName"]
    });

    this.getHouseDetails();
  }

  ngOnInit(): void {
  }

  getHouseDetails() {
    return this.queryService.getHouse(this.houseName).subscribe({
      next: response => {
        if (response) {
          this.house = response;
          this.getCharacters(response);
        }
      },
      error: err => console.log(err)
    });
  }

  getCharacters(house: any) {
    return this.queryService.getCharacters().subscribe({
      next: response => {
        if (house) {
          this.characters = response
          this.characters = this.characters.filter((c: any) => c.houseId === house.id)
        }
      },
      error: err => console.log(err),
    })
  }

}
