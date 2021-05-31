import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Game, GamePageData } from '../models/game.model';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {
  baseUrl = window.location.origin;

  gameControllerUrl = this.baseUrl + '/game';

  constructor(private http: HttpClient) { }

  getPagedGames(pageSize: number, pageNum: number){
    const url = this.gameControllerUrl + '/pagedList?pageSize=' + pageSize + '&pageNum=' + pageNum;

    return this.http.get<GamePageData>(url)
  }

  getGameById(id: number){
    const url = this.gameControllerUrl + '/getById?id=' + id;

    return this.http.get<Game>(url)
  }

  addGame(game: Game){
    const url = this.gameControllerUrl + '/addGame';

    return this.http.post<Game>(url, game);
  }

  editGame(game: Game){
    const url = this.gameControllerUrl + '/updateGame';

    return this.http.put<Game>(url, game);
  }

  deleteGame(game: Game){
    const url = this.gameControllerUrl + '/deleteGame?id=' + game.id;

    return this.http.delete<Game>(url);
  }

  searchGamesByName(query: string){
    const url = this.gameControllerUrl + '/getByName?name=' + query;

    return this.http.get<GamePageData>(url);
  }
}
