using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        public static List<Employee> emps = new List<Employee>();
        public static List<Cloth> cloth = new List<Cloth>();
        public static List<Author> authors = new List<Author>();
        public static List<Book> books = new List<Book>();

        static void Main(string[] args)
        {
         // ex1();

         // ex2();

         // ex3();

         // ex4();

          ex5();
            
        }

        private static void ex5()
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

            // Get even numbers
            var res = from n in nums
                      where n % 2 == 0
                      select n;

            Console.WriteLine("Defferred execution");
            // LINQ statement evaluated here
            foreach (var t in res)
            {
                Console.WriteLine("\t{0}", t);
            }
            Console.WriteLine();

            // Change some data in the array.
            nums[5] = 100;
            Console.WriteLine("After changing nums[5] = 100");
            // Evaluate again
            foreach (var t in res)
            {
                Console.WriteLine("\t{0}", t);
            }
            //Immediate execution
            Console.WriteLine("\nImmediate execution");

            //Get odd numbers
            var res2 = (from n in nums
                        where n % 2 == 1
                        select n).ToList();

            foreach (var t in res2)
            {
                Console.WriteLine("\t{0}", t);
            }
            nums[0] = 77;

            Console.WriteLine("After changing nums[0] = 77");

            // Evaluate again
            foreach (var t in res2)
            {
                Console.WriteLine("\t{0}", t);
            }
        }
     
        private static void ex1()
        {
            cloth.Add(new Cloth("Shoes for men", 12500));
            cloth.Add(new Cloth("Shoes for men", 15000));
            cloth.Add(new Cloth("Shoes for men", 18000));
            cloth.Add(new Cloth("Shoes for men", 19800));
            cloth.Add(new Cloth("Shoes for men", 21000));
            cloth.Add(new Cloth("Shoes for women", 12000));
            cloth.Add(new Cloth("Shoes for women", 15000));
            cloth.Add(new Cloth("Shoes for women", 18000));
            cloth.Add(new Cloth("Shoes for women", 19800));
            cloth.Add(new Cloth("Shoes for women", 21000));
            cloth.Add(new Cloth("Shoes for babies", 25000));
            
            var res = cloth.Where(x => x.Category.Contains("Shoes"));
          
            var res2 =
                (from r in res.OrderByDescending(a => a.price)
                 select r).Take(10);

            Console.WriteLine("Exercise 1");
            foreach (var t in res2)
            {
                Console.WriteLine("{0}\t\t{1}", t.Category, t.price);
            }

        }

        private static void ex2()
        {

            DateTime d1 = new DateTime(2014, 01, 01);
            DateTime d2 = new DateTime(2014, 05, 01);
            DateTime d3 = new DateTime(2015, 01, 01);
            DateTime d4 = new DateTime(2014, 01, 01);

            Employee j1 = new Employee(1, "Jane", 200, d1);
            Employee j2 = new Employee(1, "Jane", 300, d2);
            Employee j3 = new Employee(1, "Jane", 150, d3);
            Employee j4 = new Employee(2, "Bob", 500, d4);

            emps.Add(j1);
            emps.Add(j2);
            emps.Add(j3);
            emps.Add(j4);

            var res = from p in emps
                      group p by new { p.Emp_name, p.Date.Date.Year } into g
                      select new { person = g.Key, amount = g.Sum(b => b.Bonus) };


            Console.WriteLine("\nExercise 2");
            Console.WriteLine("Task 1");
            foreach (var t in res)
            {
                Console.WriteLine("{0} - ${1} in {2}", t.person.Emp_name, t.amount, t.person.Year);
            }
            Console.WriteLine("\nTask 2");
            var res2 = from p in emps
                       group p by new { p.Emp_name, p.Date.Date.Year } into g
                       select new { person = g.Key, amount = g.Count() };

            foreach (var t in res2)
            {
                Console.WriteLine("{0} - {1} times in {2}", t.person.Emp_name, t.amount, t.person.Year);
            }

            Console.WriteLine("\nTask 3");
            var res3 = from p in emps
                       group p by new { p.Emp_name, p.Date.Date.Year } into g
                       select new { person = g.Key, amount = g.Average(b => b.Bonus) };

            foreach (var t in res3)
            {
                Console.WriteLine("{0} - ${1} in {2}", t.person.Emp_name, t.amount, t.person.Year);
            }
        }
        private static void ex3()
        {
            Author a1 = new Author(1, "Jane", "Austin");
            Author a2 = new Author(2, "Joanne", "Rowling");
            Author a3 = new Author(3, "Douglas", "Adams");
            Book b1 = new Book(1, "Pride and prejudice", 1813);
            Book b2 = new Book(2, "Harry Potter and Deathly Hallows", 2007);
            // Book b3 = new Book("Dante", "Divine Comedy", 1302);
            // Book b4 = new Book("Harper Lee", "To Kill a Mockingbird", 1960);
            Book b5 = new Book(3, "The Hitchhiker's Guide to the Galaxy", 1979);

            authors.Add(a1);
            authors.Add(a2);
            authors.Add(a3);
            books.Add(b1);
            books.Add(b2);
            // books.Add(b3);
            //books.Add(b4);
            books.Add(b5);

            var res = books.SelectMany(e => authors.Where(b => b.AuthorId == e.AuthorId)
                .Select(b => new
                {
                    name = b.FirstName,
                    fname = b.LastName,
                    title = e.Title,
                    year = e.Year
                }));

            Console.WriteLine("Exercise 3");
            foreach (var t in res)
            {
                Console.WriteLine(t.name + " " + t.fname + ", " + t.title + ", " + t.year);
            }
        }
        private static void ex4()
        {
            List<Category> categories = new List<Category>()
            { 
                new Category(){Name="Beverages", ID=1},
                new Category(){ Name="Condiments", ID=2},
                new Category(){ Name="Vegetables", ID=3},
                new Category() { Name="Grains", ID=4},
                new Category() { Name="Fruit", ID=5}            
            };

            List<Product> products = new List<Product>()
           {
              new Product{Name="Cola",  CategoryID=1},
              new Product{Name="Tea",  CategoryID=1},
              new Product{Name="Mustard", CategoryID=2},
              new Product{Name="Pickles", CategoryID=2},
              new Product{Name="Carrots", CategoryID=3},
              new Product{Name="Bok Choy", CategoryID=3},
              new Product{Name="Peaches", CategoryID=5},
              new Product{Name="Melons", CategoryID=5},
            };

            var query = from p in products
                        join c in categories on p.CategoryID equals c.ID
                        select new { Name = p.Name, Categ = c.Name };

            Console.WriteLine("\nExercise 4");
            Console.WriteLine("Inner Join:");
            foreach(var t in query){
                Console.WriteLine(t.Name + " - " + t.Categ);
            }
            Console.WriteLine("\nLeft Outer:");

            var query2 =
              from c in categories
              join p in products
              on c.ID equals p.CategoryID into g
              from s in g.DefaultIfEmpty()
              select new { Categ = c.Name, ProductName = s == null ? String.Empty : s.Name };

            //var n = query2.GroupBy(t => t.Categ);

            var query3 =
                from q in query2
                group q by q.Categ into g
                select new
                {
                    Categ = g.Key,
                    ProductNames = from q2 in query2
                                   where q2.Categ.Equals(g.Key)
                                   select q2
                };

            foreach (var t in query3)
            {
                Console.WriteLine(t.Categ + ":");
                foreach (var t2 in t.ProductNames)
                {
                    Console.WriteLine("\t" + t2.ProductName);
                }
            }
           /* foreach (var t in query2)
            {
                Console.WriteLine(t.Categ + ":");
                foreach (var s in query2)
                {
                    if (t.Categ == s.Categ)
                    {
                        Console.WriteLine("\t"+s.ProductName);
                    }
                }
            }
            */
            

        }
    }
}
