using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FluentValidation.WebApi.Models
{
    public class Tester : Person
    {
        public readonly string Role;

        public Tester()
        {
            Role = "Tester";
        }
    }
}
