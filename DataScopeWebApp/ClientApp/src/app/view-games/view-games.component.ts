import { Component, OnInit } from '@angular/core';
import { Game, GamePageData } from '../models/game.model';
import { HttpServiceService } from '../services/http-service.service';

@Component({
  selector: 'app-view-games',
  templateUrl: './view-games.component.html',
  styleUrls: ['./view-games.component.css']
})
export class ViewGamesComponent implements OnInit {

  data: GamePageData = new GamePageData();
  pageSize: number = 5;
  pageNum: number = 1;
  totalPages: number = 1;

  constructor(private httpService: HttpServiceService) { }

  ngOnInit() {
    this.fetchData();
  }

  fetchData(){
    this.httpService.getPagedGames(this.pageSize, this.pageNum).subscribe({
      next: (result) => {
        this.data = result;
        this.totalPages = Math.ceil(this.data.allGamesCount / this.pageSize);
        console.log(this.totalPages);
      },
      error: (error) => {console.log('Could note retrieve data: ', error)}
    })
  }

  delete(game: Game){
    this.httpService.deleteGame(game).subscribe({
      next: (result) => {console.log('Game successfully deleted: ', result)},
      error: (error) => {console.log('Game could not be deleted: ', error)},
      complete: () => this.fetchData()
    })
  }

  changePage(value: number){
    console.log(this.pageNum, value)
    if ((this.pageNum === 1 && value < 0)
      || this.pageNum === this.totalPages && value > 0){
      return;
    }
    else {
      this.pageNum += value;
      this.fetchData();
    }
  }

}
