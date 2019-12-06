using System;
using System.Collections.Generic;
using System.Text;

namespace Task.BLL.Abstracrions
{
    public interface IServices<T> where T : ModelBase
    {
        IEnumerable<T> Get();
    }
}
