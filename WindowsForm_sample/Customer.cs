using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsForm_sample
{
    // Fix for CS8370: Replace 'record struct' with 'struct' as C# 7.3 does not support 'record struct'.  
    // Fix for CS9113: Ensure the parameters are used in the struct.  

    public struct Customer
    {
        public long Id { get; }
        public string Name { get; }

        public Customer(long id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
