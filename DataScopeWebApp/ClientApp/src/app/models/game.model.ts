export class Game{
    id: number;
    name: string;
    description: string;
    releaseDate: Date;
    rating: number;
}

export class GamePageData{
    games: Game[];
    allGamesCount: number
}