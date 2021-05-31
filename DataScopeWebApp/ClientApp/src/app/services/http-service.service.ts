import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Game, GamePageData } from '../models/game.model';

@Injectable({
  providedIn: 'root'
})
export class HttpServiceService {
  /**
   * The baseUrl (localhost:<port number>)
   */
  baseUrl = window.location.origin;

  gameControllerUrl = this.baseUrl + '/game';

  constructor(private http: HttpClient) { }

  /**
   * Returns an observable containing a paged game list instance
   * @param pageSize the size of the page
   * @param pageNum the current page number
   * @returns A GamePageData instance
   */
  getPagedGames(pageSize: number, pageNum: number){
    const url = this.gameControllerUrl + '/pagedList?pageSize=' + pageSize + '&pageNum=' + pageNum;

    return this.http.get<GamePageData>(url)
  }

  /**
   * Retrieves a single game based on ID
   * @param id the ID of the game to retrieve
   * @returns A Game instance
   */
  getGameById(id: number){
    const url = this.gameControllerUrl + '/getById?id=' + id;

    return this.http.get<Game>(url)
  }

  /**
   * Calls the Add method in the API
   * @param game the game to add
   * @returns a new Game instance
   */
  addGame(game: Game){
    const url = this.gameControllerUrl + '/addGame';

    return this.http.post<Game>(url, game);
  }

  /**
   * Calls the Edit method in the API
   * @param game the game to update
   * @returns an updated Game instance
   */
  editGame(game: Game){
    const url = this.gameControllerUrl + '/updateGame';

    return this.http.put<Game>(url, game);
  }

  /**
   * Calls the Delete method in the API
   * @param game the game to be deleted (the id will be extracted and passed into the API)
   * @returns a deleted Game instance
   */
  deleteGame(game: Game){
    const url = this.gameControllerUrl + '/deleteGame?id=' + game.id;

    return this.http.delete<Game>(url);
  }

  /**
   * Calls the GetByName method in the API to return a filtered list of games
   * @param query the query string, which may be all or part of a name
   * @returns a paged list of games
   */
  searchGamesByName(query: string){
    const url = this.gameControllerUrl + '/getByName?name=' + query;

    return this.http.get<GamePageData>(url);
  }
}
