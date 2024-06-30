using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DTO
{
    public class BarometerDto
    {
        public int BarometerId { get; set; }
        public DateTime Date { get; set; }
        public int EmployeeCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
