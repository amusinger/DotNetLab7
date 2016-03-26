using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    public class Author
    {
        public int AuthorId;
        public string FirstName;
        public string LastName;

        public Author(int id, string f, string l)
        {
            this.AuthorId = id;
            this.FirstName = f;
            this.LastName = l;
        }
    }
    public class Book
    {
        public int AuthorId;
        public string Title;
        public int Year;

        public Book(int id, string t, int y)
        {
            this.AuthorId = id;
            this.Title = t;
            this.Year = y;
        }
    }
}
