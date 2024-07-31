using EFTask2Hosbital.Models;

namespace EFTask2Hosbital
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppContext context = new AppContext();

            


            //     var q1 = from d in context.Doctors
            //             join a in context.Appointments on d.Id equals a.Doctor.Id

            ////              join dp in  context.PatientDoctors on d.Id equals dp.Doctor.Id
            //              select new {d.Id , d.Name , a.Patient.PatientName };


            //use order by for last appoitment
            var q1 = from d in context.Doctors
                     join pd in context.PatientDoctor on d.Id equals pd.Doctor.Id
                     join ap in context.Appointments on d.Id equals ap.Doctor.Id 
                     select new {paitentName = pd.patient.PatientName , DoctorName = d.Name , visit = ap.AppoinmentDate};
            foreach (var item in q1)
            {
                Console.WriteLine(item);
       
            }

            Console.WriteLine("--------------------------------------------------");

            //var q2 = context.Departments.Select(x => x.Doctors.Where(d => d.YearsOfExperince > 4)) .Select(x=> x.Select(y => new {docName = y.Name , depName = y.Department.Name})).ToList();
            //foreach (var item in q2)
            //{
            //    Console.WriteLine(item.Select(x=> new {x.depName , x.docName}));
            //}

            var q22 = context.Doctors.Where(x => x.YearsOfExperince > 4).Select(y => new {docName = y.Name , depName = y.Department.Name , years = y.YearsOfExperince});
            foreach (var item in q22)
            {
                Console.WriteLine(item);
            }



            Console.WriteLine("--------------------------------------------------");
            //displays all appoitments!!!
            var q3 = from a in context.Appointments
                     join d in context.Doctors on a.Doctor.Id equals d.Id
                     // join dep in context.Departments on d.Department.Id equals dep.Id 
                     into group_
            select new
            {
                Date = a.AppoinmentDate,
                Doc = a.Doctor.Name,
                Patient = a.Patient.PatientName,
                dep = a.Doctor.Department.Name
            };

            foreach (var item in q3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------------------------------------");


            var q4 = from pa in context.PatientDoctor
                     group pa by pa.Doctor
                     into pa_ select new
                     {
                         pa_.Key,
                        
                     };
            var q44 = context.Doctors.GroupBy(x => x.PatientDoctor)
                .Select(x => new { x.Key });
            foreach (var item in q4)
            {
                Console.WriteLine(item);
            }


            //    var q444 = context.PatientDoctor.GroupBy(x => x.Doctor)
            //.OrderBy(group => group.Key)
            //.Select(group => Tuple.Create(group.Key, group.Count()));


            //foreach (var item in q444)
            //{
            //    Console.WriteLine(item);
            //}
            //
            Console.WriteLine("--------------------------------------------------");


            var q5 = context.Appointments.Where(x => x.AppoinmentDate < new DateTime(2024, 01, 01))
                .Select(x => new { PaitentName = x.Patient.PatientName , docName =  x.Doctor.Name });
            foreach (var item in q5)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------------------------------------");

            //not sure with this
            var q6 = from pa in context.PatientDoctor                                   //where pa.patient.PatientName.Count() > 2
                                                                                        //  join d in context.Doctors on pa.Doctor.Id equals d.Id
                                                                                        //join ap in context.Appointments on  
                     group pa by pa.Doctor.Id into pa_select
                     select new { count = pa_select.Count() };
            foreach (var item in q6)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------------------------------");

            var q7 = context.Departments.OrderByDescending(x => x.Doctors.Count()).Take(3).Select(x=> new {deptName = x.Name });

            foreach (var item in q7)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("--------------------------------------------------");

            var q8 = context.Appointments.Where(x => x.AppoinmentDate == DateTime.Today).Select(x => new { x.AppoinmentDate, x.Id });
            foreach (var item in q8)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("--------------------------------------------------");

            var q9 = from d in context.Doctors
                     join pd in context.PatientDoctor on d.Id !equals pd.Doctor.Id
                     where d.Id != pd.Doctor.Id
                     select new
                     {
                         docName = d.Name,
                         docSpecialist = d.Specialty
                     };

            foreach (var item in q9)
            {
                Console.WriteLine(item);
            }
        }
    }
}
