using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    internal class DataBase
    {
        List<Flat> database = new List<Flat>();
        public uint GetLastElementId => database.Count == 0 ? 0 : database.Last().id;
        public void AddFlat(Flat flat)
        {
            database.Add(flat);
        }
        public void DeleteFlat(int id)
        {
            Flat temp = database.Find(item => item.id == id);
            database.Remove(temp);
        }

        public void UpdatePrice(int id, float price)
        {
            Flat temp = database.Find(item => item.id == id);
            temp.price = price;
        }

        public void UpdateAdress(int id, string address)
        {
            Flat temp = database.Find(item => item.id == id);
            temp.address = address;
        }

        public float GetAverage()
        {
            float average = 0;
            foreach (Flat item in database)
            {
                average += item.price;
            }
            return average /= database.Count;
        }

        public string GetFullInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var flat in database)
            {
                sb.Append("ID: ").AppendLine(flat.id.ToString());
                sb.Append("Rooms: ").AppendLine(flat.rooms.ToString());
                sb.Append("Price: ").AppendLine(flat.price.ToString());
                sb.Append("Address: ").AppendLine(flat.address);
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
