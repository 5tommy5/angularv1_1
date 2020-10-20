import { Component, OnInit } from '@angular/core';
import { DogService } from './dog.service';
import { DataService } from './data.service';
import { Dog } from './dog';
@Component({
  selector: 'app-dog',
  templateUrl: './dog.component.html',
  styleUrls: ['./dog.component.css'],
  providers: [DataService]
})
export class DogComponent implements OnInit {
  dog: Dog = new Dog();   // изменяемый товар
  dogs: Dog[];                // массив товаров
  tableMode: boolean = true; 
  constructor(private dataService: DataService) { }

  ngOnInit() {
    this.loadDogs();    // загрузка данных при старте компонента  
  }
  loadDogs() {
    this.dataService.getDogs()
      .subscribe((data: Dog[]) => this.dogs = data);
  }
  save() {
    if (this.dog.id == null) {
      this.dataService.createDog(this.dog)
        .subscribe((data: Dog) => this.dogs.push(data));
    } else {
      this.dataService.updateDog(this.dog)
        .subscribe(data => this.loadDogs());
    }
    this.cancel();
  }
  editDog(d: Dog) {
    this.dog = d;
  }
  cancel() {
    this.dog = new Dog();
    this.tableMode = true;
  }
  delete(d: Dog) {
    this.dataService.deleteDog(d.id)
      .subscribe(data => this.loadDogs());
  }
  add() {
    this.cancel();
    this.tableMode = false;
  }
}

