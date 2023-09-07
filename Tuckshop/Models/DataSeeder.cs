using Tuckshop.Areas.Identity.Data;

namespace Tuckshop.Models
{
    public class DataSeeder
    {
        private readonly TuckshopContext tuckshopContext;

        public DataSeeder(TuckshopContext tuckshopContext) 
        {
            this.tuckshopContext = tuckshopContext;
        }

        public void Seed()
        {
            Seed(tuckshopContext);
        }

        public void Seed(TuckshopContext tuckshopContext) 
        {
         if(!tuckshopContext.Student.Any()) 
            {
                var students = new List<Student>()
                {
                    new Student()
                    {
                      FirstName= "Muhammad",
                      LastName= "Shahryar",
                      Homeroom= "1"
                    },
                    new Student()
                    {
                     FirstName= "Eric",
                     LastName= "Zhuang",
                     Homeroom= "1"
                    },
                    new Student()
                    {
                     FirstName= "Peter",
                     LastName= "Pentigal",
                     Homeroom= "1"
                    },
                    new Student()
                    {
                     FirstName= "Stacey",
                     LastName= "Grover",
                     Homeroom= "2"
                    },
                     new Student()
                    {
                     FirstName= "Rune",
                     LastName= "Scaper",
                     Homeroom= "2"
                    },
                      new Student()
                    {
                     FirstName= "Huey",
                     LastName= "Riley",
                     Homeroom= "2"
                    },
                };
                tuckshopContext.Student.AddRange(students);
                tuckshopContext.SaveChanges();
            }
        }
    }
}
