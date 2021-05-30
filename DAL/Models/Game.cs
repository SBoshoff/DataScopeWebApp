﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DAL.Models
{
    public class Game : ModelBase
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int Rating { get; set; }
    }

    public class GamePageData
    {
        public List<Game> Games { get; set; }
        public int AllGamesCount { get; set; }
    }
}
