using ManyToMany.Context;
using ManyToMany.Entities;

namespace ManyToMany
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (SchoolDbContext context= new SchoolDbContext())
            {
                Course c1 = new Course()
                {
                    Title = "Maths"

                };
                Course c2 = new Course()
                {
                    Title = "English"


                };

                Instructor ins = new Instructor()
                {
                    Name = "Ali",
                    Bonus = 100.20M,
                    Salary = 1000,
                    Address="Shatby",
                    HourRate=10,
                    DeptId=10

                };

            }
        }
    }
}
