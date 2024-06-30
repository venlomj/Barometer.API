using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Barometer.DTO
{
    public class BarometerRequest
    {

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "EmployeeCount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "EmployeeCount must be greater than 0")]
        public int EmployeeCount { get; set; }
    }
}
