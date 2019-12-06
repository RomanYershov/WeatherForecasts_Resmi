
using Task.BLL.Models;

namespace Task.BLL.Abstracrions
{
    public interface IForecastService : IServices<ForecastModel>
    {
        int Degree { get; } 
        void Add(ForecastModel model);
    }
}
