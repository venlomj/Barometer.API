using Barometer.DAL.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DAL
{
    public class BarometerContext : DbContext
    {
        public BarometerContext(DbContextOptions<BarometerContext> options) : base(options)
        {
            
        }
        
        public DbSet<BarometerModel> Barometers { get; set; }
    }
}
