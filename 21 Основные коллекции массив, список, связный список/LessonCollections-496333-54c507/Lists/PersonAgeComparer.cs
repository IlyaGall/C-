using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    internal class PersonAgeComparer : IComparer<Person>
    {
        int IComparer<Person>.Compare(Person x, Person y)
        {
            return x.Age - y.Age;
        }
    }
}
