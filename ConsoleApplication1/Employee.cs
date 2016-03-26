using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Employee
    {
        public int Emp_id;
        public string Emp_name;
        public int Bonus;
        public DateTime Date;


        public Employee(int ID, string name, int bonus, DateTime date) 
        {
            this.Emp_id = ID;
            this.Emp_name = name;
            this.Bonus = bonus;
            this.Date = date;

        }


    }
}
