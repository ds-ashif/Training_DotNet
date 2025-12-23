using System;
using System.Collections.Generic;


namespace Day4Constructor
{
     
     //exercise: only set use

        public class Sum
    {
        public int Num1{get; set;}
        public int Num2{get;set;}

        public int Result{get;}  

        public Sum(int num1,int num2)
        {
            Num1=num1;
            Num2=num2;

            Result=Num1+Num2;  // oly in constructor  get property can set the values
            
        

            

        }
    }
}    
        
    
