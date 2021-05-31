
/**
 * The main Game model
 */
export class Game{
    id: number;
    name: string;
    description: string;
    releaseDate: Date;
    rating: number;
}

/**
 * A composed game list model
 * Consists of a list of games as well as a count of all games to facilitate paging
 */
export class GamePageData{
    games: Game[];
    allGamesCount: number
}