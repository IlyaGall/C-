using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lambdas
{
    internal class Class1
    {

        static void ds() 
        {
            var collection1 = new List<int>
            {
                -1, -2, -15, -16, -200, -14
            };

            var collection5 = Filter(collection1, delegate (int i)
            {
                return i != 3;
            });
        }


        static List<int> Filter(List<int> collection, Func<int, bool> criteriaDelegate)
        {
            var result = new List<int>();

            foreach (var i in collection)
            {
                if (criteriaDelegate(i))
                {
                    result.Add(i);
                }
            }

            return result;
        }
    }
}
