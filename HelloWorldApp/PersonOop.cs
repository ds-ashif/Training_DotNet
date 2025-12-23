using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HelloWorldApp
{
    
    public class Person
    {
        public int Id{get; set; }
        public int Age{get; set; }
        public string Name{get; set; }

    }

    public class Man : Person
    {
        public string Playing{get; set; }
    }
    public class Woman : Person
    {
        public string PlayingAndManagement{get; set; }
    }

    public class Child : Person
    {
        public string Studies{get; set; }
    }
}