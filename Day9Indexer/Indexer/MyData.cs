using System;
using System.Collections.Generic;
using System.Text;

namespace Indexer
{
    /// <summary>
    /// Represents a collection of three string values accessible by index.
    /// </summary>
    /// <remarks>Use the indexer to get or set individual string values by their zero-based index. The valid
    /// index range is 0 to 2, inclusive.</remarks>
    public class MyData
    {
        private string[] values = new string[3]; // Internal array to hold string values

        public string this[int index] // Indexer to get/set values by index
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }

    }
}
