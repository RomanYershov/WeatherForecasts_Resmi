
using Task.BLL.Models;

namespace Task.BLL.Abstracrions
{
    public interface IForecastService : IServices<ForecastModel>
    {
        int Temperature { get; } 
        void Add(ForecastModel model);
    }
}
