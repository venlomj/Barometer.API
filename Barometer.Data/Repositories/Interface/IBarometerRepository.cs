using Barometer.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DAL.Repositories.Interface
{
    public interface IBarometerRepository
    {
        Task<IEnumerable<BarometerModel>> GetAllBarometersAsync();
        Task<BarometerModel> GetBarometerByIdAsync(int id);
        Task<BarometerModel> CreateBarometerAsync(BarometerModel barometer);
        Task<BarometerModel> UpdateBarometerAsync(BarometerModel barometer);
        Task<bool> DeleteBarometerAsync(int id);
    }
}
