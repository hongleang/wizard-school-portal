import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { HouseResponse } from '../model/House';



@Injectable({
  providedIn: 'root'
})



export class QueryServiceService {
  baseUrl = 'https://localhost:5500/api/';

  constructor(private httpClient: HttpClient) { }

  getHouses() {
    return this.httpClient.get<HouseResponse[]>(this.baseUrl + 'houses').pipe(
      map(response => response))
  }
}


