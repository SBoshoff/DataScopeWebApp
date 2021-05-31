using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    /// <summary>
    /// Provides an abstract class type for future DbSet objects to inherit from
    /// </summary>
    public class ModelBase
    {
        public int id { get; set; }
    }
}
