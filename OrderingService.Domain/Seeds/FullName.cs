using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace OrderingService.Domain.Seeds
{
    [Owned]
    public class FullName : ValueObject
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
        protected override IEnumerable<object> GetEqualityComponents()
        {
            // Using a yield return statement to return each element one at a time
            yield return Name;
            yield return LastName;
            yield return MiddleName;

        }
    }

}
