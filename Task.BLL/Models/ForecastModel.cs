using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Task.BLL.Abstracrions;

namespace Task.BLL.Models
{
    public class ForecastModel : ModelBase
    {
        public string PlayerName { get; set; }
        public string Phone { get; set; }
        public int Degree { get; set; }
        public DateTime DateTime { get; set; }

        public override string ToString()
        {
            return $"ID: {Id} , C: {Degree}, Date: {DateTime}";
        }
    }
}
