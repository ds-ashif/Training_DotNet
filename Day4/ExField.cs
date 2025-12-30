using System;
using System.Collections.Generic;
using System.Dynamic;

namespace Day4Constructor
{
    public class Employee
    {
        private int id;

        public int Id
        {
            set
            {
                if(value>0)
                {
                    id=value;
                }
                else
                {
                    id=0;
                    throw new InvalidOperationException("How id can be less than Zero");
                }
            }
        }

        // public int Id{get=>id; set=>id=value;}

        public string DisplayEmployeeDetails()
        {
            return $"Employee Id is {id}";   
        }
    }
}