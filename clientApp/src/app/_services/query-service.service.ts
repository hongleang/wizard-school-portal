import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map, ReplaySubject } from 'rxjs';
import { User } from '../model/User';

@Injectable({
  providedIn: 'root'
})
export class QueryServiceService {
  baseUrl = 'https://localhost:5500/api/';

  constructor(private httpClient: HttpClient) { }

  getHouses() {
    return this.httpClient.get(this.baseUrl + 'houses').pipe(
      map(response => response))
  }

  getHouse(name: string) {
    return this.httpClient.get(this.baseUrl + 'houses' + '/' + name).pipe(
      map(response => response))
  }

  getCharacters() {
    return this.httpClient.get(this.baseUrl + 'characters').pipe(
      map(response => response))
  }

  getUserDetails(userObject: any) {
    console.log(userObject)
    return this.httpClient
      .get(this.baseUrl + 'users/' + userObject.username,
        { headers: { "Authorization": `Bearer ${userObject.token}` } })
      .pipe(map(response => response))
  }

}


