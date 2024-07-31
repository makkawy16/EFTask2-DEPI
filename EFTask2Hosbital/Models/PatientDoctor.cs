using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2Hosbital.Models
{
    public class PatientDoctor
    {
        public int Id { get; set; }
        public virtual Doctor Doctor { get; set; }
        public virtual Patient patient { get; set; }
    }
}
