import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Dog } from './dog';

@Injectable()
export class DataService {

  private url = "/api/Dog";

  constructor(private http: HttpClient) {
  }

  getDogs() {
    return this.http.get(this.url);
  }

  getDog(id: number) {
    return this.http.get(this.url + '/' + id);
  }

  createDog(dog: Dog) {
    return this.http.post(this.url, dog);
  }
  updateDog(dog: Dog) {

    return this.http.put(this.url, dog);
  }
  deleteDog(id: number) {
    return this.http.delete(this.url + '/' + id);
  }
}
