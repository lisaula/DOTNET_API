using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_CodeFirst.models;
using Entity_CodeFirst.context;

namespace Entity_CodeFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create and save a new Blog 
            var db = new SchoolContext();
            //Console.Write("Enter a name for a new Blog: ");
            //var name = Console.ReadLine();

            //var student = new Student { Firstname = "Carson", Lastname = "Alexander", EnrollmentDate = DateTime.Parse("2005-09-01") };
            //db.Students.Add(student);
            //db.SaveChanges();

            // Display all Blogs from the database 
            var query = from b in db.Students
                        orderby b.Firstname
                        select b;

            Console.WriteLine("All blogs in the database:");
            foreach (var item in query)
            {
                Console.WriteLine(item.Firstname);
            }

            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
