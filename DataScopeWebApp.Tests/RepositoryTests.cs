using DAL.Context;
using DAL.Models;
using DAL.Repositories;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;

namespace DataScopeWebApp.Tests
{
    public class Tests
    {
        private AppDbContext _context;
        private GameRepository _repository;

        private int lastInsertedId;
        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer("server=localhost; database=GameDB; Trusted_Connection=true");
            _context = new AppDbContext(optionsBuilder.Options);
            _repository = new GameRepository(_context);
        }

        [Test]
        public void GetListTest()
        {
            // Arrange

            //Act
            var result = _repository.GetPagedList(5, 1).Result;

            //Assert
            Assert.IsNotEmpty(result);
        }

        [Test]
        public void GetListTestZeroPageNum()
        {
            // Arrange

            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => _repository.GetPagedList(5, 0));
        }

        [Test]
        public void GetListTestZeroPageSize()
        {
            // Arrange

            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => _repository.GetPagedList(0, 1));
        }

        [Test]
        public void GetListTestZero()
        {
            // Arrange

            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => _repository.GetPagedList(0, 0));
        }

        [Test]
        public void GetListTestNegatives()
        {
            // Arrange

            //Act

            //Assert
            Assert.ThrowsAsync<ArgumentException>(() => _repository.GetPagedList(5, -1));
        }

        [Test]
        public void AddGameTest()
        {
            //Arrange
            Game game = new Game();
            game.Name = "Test Game";
            game.Description = "Unit Testing Game";
            game.ReleaseDate = DateTime.Now;
            game.Rating = 4;

            //Act
            var result = _repository.Insert(game).Result;
            if (result != null)
            {
                lastInsertedId = result.id;
            }

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(game.Name == "Test Game");
        }

        [Test]
        public void AddEmptyGameTest()
        {
            //Arrange
            Game game = new Game();

            //Act
            var result = _repository.Insert(game).Result;

            //Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void PutGameTest()
        {
            //Arrange
            Game game = new Game();
            game.id = lastInsertedId;
            game.Name = "Test Game Update";
            game.Description = "Unit Testing Game Update";
            game.ReleaseDate = DateTime.Now;
            game.Rating = 4;

            //Act
            var result = _repository.Update(game).Result;
            if (result != null)
            {
                lastInsertedId = result.id;
            }

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(game.Name != "Test Game");
            Assert.IsTrue(game.Name == "Test Game Update");
        }

        [Test]
        public void RemoveGameTest()
        {
            //Arrange
            var id = lastInsertedId;

            //Act
            Assert.IsNotNull(_repository.Get(lastInsertedId).Result);
            var result = _repository.Delete(id).Result;

            //Assert
            Assert.IsNotNull(result);
            Assert.IsNull(_repository.Get(lastInsertedId).Result);
        }
    }
}