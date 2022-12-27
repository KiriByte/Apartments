using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    internal class Flat
    {
        public uint id;
        public byte rooms;
        public float price;
        public string address;

        public Flat(uint id, byte rooms, float price, string address)
        {
            this.id = id;
            this.rooms = rooms;
            this.price = price;
            this.address = address;
        }
    }
}
