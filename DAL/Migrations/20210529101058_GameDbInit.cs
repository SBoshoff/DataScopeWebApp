using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class GameDbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.id);
                });
            List<Game> gameList = new List<Game>();
            gameList.Add(new Game(1, "Factorio", "Factory Game", new DateTime(2016, 2, 26), 10));
            gameList.Add(new Game(2, "XCOM 2", "Alien fighting game", new DateTime(2016, 2, 5), 8));
            gameList.Add(new Game(3, "Terraria", "Sidescroller Game", new DateTime(2011, 5, 16), 9));
            gameList.Add(new Game(4, "Rimworld", "Colony management sim", new DateTime(2016, 7, 15), 7));
            gameList.Add(new Game(5, "Total War: Shogun 2", "Sengoku-era turn-based/real-time strategy game", new DateTime(2011, 3, 15), 9));
            gameList.Add(new Game(6, "Deus Ex", "Cyberpunk RPG", new DateTime(2000, 6, 23), 10));
            gameList.Add(new Game(7, "Morrowind", "Open-world fantasy RPG", new DateTime(2002, 2, 26), 10));
            gameList.Add(new Game(8, "Brigador", "Isometric mech combat game", new DateTime(2016, 6, 2), 8));
            gameList.Add(new Game(9, "Battle Brothers", "Low-fantasy turn-based strategy", new DateTime(201, 4, 27), 10));
            gameList.ForEach(g =>
            {
                migrationBuilder.InsertData("Games", new[] { "Name", "Description", "ReleaseDate", "Rating" }, new object[] { g.Name, g.Description, g.ReleaseDate, g.Rating });
            });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
