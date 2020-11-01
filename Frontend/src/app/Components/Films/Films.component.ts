import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-Films',
  templateUrl: './Films.component.html',
  styleUrls: ['./Films.component.css']
})
export class FilmsComponent implements OnInit {

 films: any;

  constructor(private http: HttpClient) { 

  }


  // This need to be moved into a service and a global varible.

  ngOnInit() {
    this.http.get('http://localhost:5000/api/starwars/films').subscribe(response => {
      this.films = response;
    }, error => {
      console.log(error);
    });
    
  }

  getFilm(url: string) {

  }

}
