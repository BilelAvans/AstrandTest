using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AstrandTest.Tests
{
    public class WhileAstrandRequirements
    {

        public int requestedPower { get; set; }
        public int actualPower { get; set; }
        public TimeSpan sessionTime { get; set; }
        public int distance { get; set; }
        public int energy { get; set; }
        public int pulse { get; set; }
        public int rpm { get; set; } = 60;
        public int speed { get; set; }
        public int id { get; set; }

        public int AllowedOffset { get; set; }




        public WhileAstrandRequirements()
        {

        }


    }
}
