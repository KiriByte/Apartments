using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    internal class Realtor : INotifyAll
    {
        public string name;

        public Realtor(string name) { this.name = name; }

        public string Notify(string s)
        {
            return $"Dear realtor {name}. {s}";
        }
    }
}
