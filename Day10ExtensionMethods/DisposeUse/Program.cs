using System;
using System.Collections.Generic;
using System.Data.Common;

namespace DisposeUse
{
    public class Program
    {
        BigGirl bigGirl=new BigGirl();
        try{
            bigGirl Names=new System.Collections.ArrayList();
            for(int i=0;i<10;i++){
                bigGirl.Names.Add(int.ToString());
            }
        }
        Catch(Exception ex){
            throw;
        }
        finally{
            bigGirl.Dispose();
        }
    }
}