import { Component, OnInit } from '@angular/core';
import { Game, GamePageData } from '../models/game.model';
import { HttpServiceService } from '../services/http-service.service';

@Component({
  selector: 'app-view-games',
  templateUrl: './view-games.component.html',
  styleUrls: ['./view-games.component.css']
})
/** Main component for viewing all games in the database */
export class ViewGamesComponent implements OnInit {

  data: GamePageData = new GamePageData();
  pageSize: number = 5;
  pageNum: number = 1;
  totalPages: number = 1;
  searchQuery: string = '';

  constructor(private httpService: HttpServiceService) { }

  ngOnInit() {
    this.fetchData();
  }

  /**
   * Fetches a paged list of games from the API
   * Uses bound values pageSize and pageNum
   */
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

  /**
   * Calls the delete method in the API 
   * @param game
   */
  delete(game: Game){
    this.httpService.deleteGame(game).subscribe({
      next: (result) => {console.log('Game successfully deleted: ', result)},
      error: (error) => {console.log('Game could not be deleted: ', error)},
      complete: () => this.fetchData()
    })
  }

  /**
   * Changes page data of the list
   * @param value can either be 1 (next) or -1 (previous), which gets added to the current page value
   * @returns void if page data is invalid
   */
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

  /**
   * Filters data from the API based on bound name value
   */
  filterData(){
    console.log(this.searchQuery);
    if (this.searchQuery === ''){
      this.fetchData();
    }
    else {
      this.httpService.searchGamesByName(this.searchQuery).subscribe({
        next: (result) => {this.data = result},
        error: (error) => {console.log("Could not filter list: ", error)}
      })
    }
  }

}
