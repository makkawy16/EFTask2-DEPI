using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2Hosbital.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public int YearsOfExperince { get; set; }
        public string Specialty { get;set; }
        public string Email { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<PatientDoctor> PatientDoctor {  get; set; }
        

    }
}
