using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2Hosbital.Models
{
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Head {  get; set; }
        public virtual ICollection<Doctor> Doctors { get; set; }
    }
}
