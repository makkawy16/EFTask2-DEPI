using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFTask2Hosbital.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string PatientName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public virtual ICollection<PatientDoctor> PatientDoctor { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }

    }
}
