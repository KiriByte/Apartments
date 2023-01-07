using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    public class Client:INotifyFlatAdded
    {
        public string name;

        public Client(string name) { this.name = name; }


        public string Notify(string s)
        {
            return $"Dear client {name}. {s}";
        }
    }
}
