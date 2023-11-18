using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FormulaApp.Api.Models;

namespace FormulaApp.UnitTests.Fixtures
{
    public class FanFixtures
    {
        public static List<Fan> GetFans() => new()
            {
                new Fan()
                {
                    Email = "ab@gmail.com",
                    Id = 1,
                    Name = "Joe"
                },
                new Fan()
                {
                    Email = "d@gmail.com",
                    Id = 2,
                    Name = "Doe"
                }
            };
    }
}