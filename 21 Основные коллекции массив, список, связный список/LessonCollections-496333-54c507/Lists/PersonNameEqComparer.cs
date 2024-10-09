using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    internal class PersonNameEqComparer : IEqualityComparer<Person>
    {
        bool IEqualityComparer<Person>.Equals(Person x, Person y)
        {
            return x.Name.Equals(y.Name);
        }

        int IEqualityComparer<Person>.GetHashCode(Person obj)
        {
            return 0;
        }
    }
}
