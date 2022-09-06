using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation.WebApi.Models
{
    public class Developer : Person
    {
        public readonly string Role;

        public Developer()
        {
            Role = "Developer";
        }
    }
}
