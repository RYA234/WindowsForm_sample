using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WindowsForm_sample
{
    public class SampleTest
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        // テストメソッド  
        [Fact]
        public void Test()
        {
            Assert.Equal(2, Add(1, 1));
        }
    }
}
