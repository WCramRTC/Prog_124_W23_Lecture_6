using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Prog_124_W23_Lecture_6.Examples.Inheirtance_Display
{
    internal class Transportation
    {
        public string Name;
        static int count;

        public Transportation(string Name)
        {
            this.Name = Name;
            count++;
        }

        public override string ToString()
        {
            return $"{Name}{count}";
        }
    }
}
