import { formatDate } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Game } from '../models/game.model';
import { HttpServiceService } from '../services/http-service.service';

@Component({
  selector: 'app-edit-game',
  templateUrl: './edit-game.component.html',
  styleUrls: ['./edit-game.component.css']
})
export class EditGameComponent implements OnInit {
  game: Game = new Game();

  gameForm = new FormGroup({
    name: new FormControl(this.game.name),
    description: new FormControl(this.game.description),
    dateReleased: new FormControl(this.game.releaseDate),
    rating: new FormControl(this.game.rating)
  })


  constructor(private httpService: HttpServiceService, private route: Router, private activateRoute: ActivatedRoute) { }

  ngOnInit() {
    this.activateRoute.queryParams.subscribe(param => {
      console.log(param);
      if (param.id){
        this.fetchGame(parseInt(param.id));
      }
    })
  }

  fetchGame(id: number){
    this.httpService.getGameById(id).subscribe({
      next: (result: Game) => {
        this.game = result;
        this.gameForm.patchValue({
          name: result.name,
          description: result.description,
          dateReleased: formatDate(new Date(result.releaseDate), 'yyyy-MM-dd', 'en-US'),
          rating: result.rating,
        })
      },
      error: error => {console.log("Could not retrieve data: ", error)}
    })
  }

  onSubmit(){
    this.game.name = this.gameForm.get('name').value;
    this.game.description = this.gameForm.get('description').value;
    this.game.releaseDate = this.gameForm.get('dateReleased').value;
    this.game.rating = this.gameForm.get('rating').value;

    if (!this.game.id){
      this.httpService.addGame(this.game).subscribe({
        next: (result) => {console.log("Successfully added game: ", result)},
        error: error => {console.log("Could not add game, ", error)},
        complete: () => {this.route.navigate(['/view'])}
      });
    }
    else{
      this.httpService.editGame(this.game).subscribe({
        next: (result) => {console.log("Successfully updated game: ", result)},
        error: error => {console.log("Could not update game, ", error)},
        complete: () => {this.route.navigate(['/view'])}
      });;
    }
  }

  onCancel(){
    this.route.navigate(['/view']);
  }

}
