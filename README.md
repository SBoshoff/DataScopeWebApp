# DataScopeWebApp

This is my project for the DataScope coding exercise. It is a simple CRUD-enabled web application that displays a list of games, as well as allowing users to add, edit or remove games.

## Software Used

* .NET Core 3.1
* Angular 8.2
* Entity Framework Core 5.0.6
* NUnit and Moq for unit tests

## Requirements

* Visual Studio 2019
* SQL Server Management Studio 2019

## To Run

* To set up the database, open the Package Manager console in VS, set the Default Project to DAL, and run `update-database`.
  * Confirm that the Database "GamesDB" is created and populated with 9 items.
* Run the application through Visual Studio.

## Notes

* Unit tests are fairly sparse and only cover repository operations. While they do cover all CRUD operations, they are most comprehensive around fetching paged lists.
