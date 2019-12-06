using System;
using System.Collections.Generic;
using System.Text;

namespace Task.DAL.Abstractions
{
    public abstract class Person : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
