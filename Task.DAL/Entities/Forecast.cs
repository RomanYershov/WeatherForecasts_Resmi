using System;
using System.Collections.Generic;
using System.Text;
using Task.DAL.Abstractions;

namespace Task.DAL.Entities
{
    public class Forecast : IEntity
    {
        public int Id { get; set; }
        public int PlayerId { get; set; }   
        public virtual Player Player { get; set; }  
        public int Degree { get; set; }
        public DateTime DateTime { get; set; }  
    }
}
