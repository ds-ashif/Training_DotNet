using System;
using System.Collections.Generic;

namespace Day4Constructor
{
    public class Visitor
    {
        public int Id{get; set;}    //8 Bytes
        public string Name{get; set;}   //16Bytes
        public string Requirement{get; set;}   //16Bytes

        public string LogHistory{get; set;}  //16Bytes


    //   private Visitor()
    //     {
    //         Id=0;
    //         Name="Unknown";
    //         Requirement="Not Specified";
    //     }
     

    //  public Visitor()
    //     {
           
    //     }

    public Visitor()
     {
        LogHistory="";
          LogHistory+=$"Object created at: {DateTime.Now.ToString()} {Environment.NewLine}";
        }

        public Visitor(int id):this()
        {
            LogHistory+=$"Id crt at: {DateTime.Now.ToString()} {Environment.NewLine}";
            this.Id=id;
        }

        public Visitor(int id,string name):this(id)
        {
            // this.Id=id;
            if (name.ToLower().Contains("idiot"))
            {
                throw new ArgumentException("Inappropriate Name");
            }
            LogHistory+=$"Name created at: {DateTime.Now.ToString()} {Environment.NewLine}";
            this.Name=name;

        }

        public Visitor(int id,string name,string requirement):this(id,name)
        {
            // this.Id=id;
            
            // this.Name=name;
            LogHistory+=$"Requirecreated at: {DateTime.Now.ToString()} {Environment.NewLine}";
            this.Requirement=requirement;


            
        }

        

        
        

        // public Visitor(int id,string name,string requirement)
        // {
        //     this.Id=id;
        //     this.Name=name;
        //     this.Requirement=requirement;
        // }    
        

    }    
        
    
}