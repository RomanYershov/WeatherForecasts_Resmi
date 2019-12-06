using System;
using System.Collections.Generic;
using System.Text;
using Task.DAL.Abstractions;

namespace Task.DAL.Entities
{
    public class Player : Person
    {
        public string Phone  { get; set; }
        public virtual Forecast Forecast { get; set; }  
    }
}
