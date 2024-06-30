using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DAL.Model
{
    [Table("Barometer")]
    public class BarometerModel
    {
        [Key]
        [Column("barometer_id")]
        public int BarometerId { get; set; }
        [Column("date")]
        public DateTime Date { get; set; }
        [Column("employee_count")]
        public int EmployeeCount { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
