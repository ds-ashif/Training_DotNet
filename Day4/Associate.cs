using System;

namespace Day4Constructor
{
    public class Associate
    {
        private int id{get; set;}
        public string ErrorMeassage;
        public int Id
        {
            set
            {
                if (value > 0)
                {
                    id=value;
                    ErrorMeassage+="Valid id and ";
                }
                else
                {
                    value=0;
                    ErrorMeassage+="Id must be greater than 0";
                }
            }
        }

        
        private string name{get; set;}

        public string Name
        {
            set
            {
                if (value != null)
                {
                    name=value;
                    ErrorMeassage+="Valid name";

                }
                else
                {
                    name="Not Entered";
                    ErrorMeassage+=" and Enter valid Associate name";
                    // throw new InvalidOperationException("Enter name");

                }
            }
        }

        public string DisplayAssociateDetails()
        {
            return $"Associate id is {id} and name is {name}.";
        }
        

        
    }
}
