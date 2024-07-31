using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2Hosbital.Models
{
    public class Appointment
    {
        
        public int Id { get; set; }
       // [Required]
        public DateTime AppoinmentDate { get; set; }
       // [MaxLength(500)]
        public string Reason { get; set; }

        public virtual Patient Patient { get; set; }
        public virtual Doctor Doctor { get; set; }
    }
}
