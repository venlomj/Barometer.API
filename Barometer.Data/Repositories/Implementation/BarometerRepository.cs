using Barometer.DAL.Model;
using Barometer.DAL.Repositories.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DAL.Repositories.Implementation
{
    public class BarometerRepository : IBarometerRepository
    {
        private readonly BarometerContext _context;
        public BarometerRepository(BarometerContext context)
        {
            _context = context;
        }

        public async Task<BarometerModel> CreateBarometerAsync(BarometerModel barometer)
        {
            _context.Barometers.Add(barometer);
            await _context.SaveChangesAsync();
            return barometer;
        }

        public async Task<bool> DeleteBarometerAsync(int id)
        {
            var barometer = await GetBarometerByIdAsync(id);
            if (barometer == null)
            {
                return false;
            }
            _context.Barometers.Remove(barometer);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<BarometerModel>> GetAllBarometersAsync()
        {
            return await _context.Barometers.ToArrayAsync();
        }

        public async Task<BarometerModel> GetBarometerByIdAsync(int id)
        {
            return await _context.Barometers.FindAsync(id);
        }

        public async Task<BarometerModel> UpdateBarometerAsync(BarometerModel barometer)
        {
            _context.Barometers.Update(barometer);
            await _context.SaveChangesAsync();
            return barometer;
        }
    }
}
