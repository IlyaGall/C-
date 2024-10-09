using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    internal class Person : IComparable<Person>, IEquatable<Person>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public int CompareTo(Person other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public bool Equals(Person other)
        {
            return this.Id == other.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Age, Id);
            //return 0;
        }
    }
}
