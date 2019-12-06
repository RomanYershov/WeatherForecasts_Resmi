using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Task.BLL.Abstracrions;

namespace Task.BLL.Models
{
    public class ForecastComparer : IComparer<ForecastModel>
    {
        
        private readonly int _degree;
        public ForecastComparer(int degree) => _degree = degree;
        public int Compare(ForecastModel x, ForecastModel y)
        {
            if (Math.Abs(x.Degree - _degree) < Math.Abs(y.Degree - _degree))
                return -1;
            if (Math.Abs(x.Degree - _degree) > Math.Abs(y.Degree - _degree))
                return 1;
            return 0;
        }
    }
}
