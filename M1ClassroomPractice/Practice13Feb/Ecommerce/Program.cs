using System;
using System.Collections.Generic;

class Program
{
    public static Dictionary<string,int> CountCartQuantity(List<(string sku, int qty)> scans)
    {
        Dictionary<string,int> skuQty = new Dictionary<string, int>();
        
        foreach(var entry in scans)
        {
            if(entry.Item2<=0) continue;

            if (!skuQty.ContainsKey(entry.Item1))
            {
                
                    skuQty[entry.Item1] = entry.Item2;
                
            }
            else
            {
                skuQty[entry.Item1]+=entry.Item2;
            }
        }
        return skuQty;
    }
    static void Main()
    {
        var input = new List<(string, int)> {("A101",2),("B205",1),("A101",3),("C111",-1)};
        var result = CountCartQuantity(input);
        foreach(var item in result)
        {
            Console.WriteLine($"{item.Key}: {item.Value}");
        }
    }
}