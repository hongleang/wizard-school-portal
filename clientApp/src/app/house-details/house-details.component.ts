import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HouseResponse } from '../model/House';
import { QueryServiceService } from '../_services/query-service.service';

@Component({
  selector: 'app-house-details',
  templateUrl: './house-details.component.html',
  styleUrls: ['./house-details.component.css']
})
export class HouseDetailsComponent implements OnInit {
  houseName: string = '';
  house: HouseResponse = <HouseResponse>{ };

  constructor(private queryService: QueryServiceService, private route: ActivatedRoute) {
    route.params.subscribe((params) => {
      this.houseName = params["houseName"]
    });

    this.getHouseDetails();
  }

  ngOnInit(): void {
  }

  getHouseDetails() {
    return this.queryService.getHouses().subscribe({
      next: (response)=> {
        if(response !== null){
          this.house = response?.find(r => r.name === this.houseName) || <HouseResponse>{ };          
        }        
      },
      error: err => console.log(err)
    });
  }
}
