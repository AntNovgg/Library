using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Entities.RenterAggregate
{
    public class FullName // ValueObject
    {
        public string Name { get; private set; }
        public string LastName { get; private set; }
        public string MiddleName { get; private set; }
        private FullName() { }

        public FullName(string name,
            string lastName,
            string middleName)
        {
            Name = name;
            LastName = lastName;
            MiddleName = middleName;
        }
    }
}
