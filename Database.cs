using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    internal class DataBase
    {
        public event Action<string>? NotifyFlatAdded;
        public event Action<string>? NotifyFlatDeleted;
        public event Action<string>? NotifyFlatUpdatedPrice;
        public event Action<string>? NotifyFlatUpdatedAddress;

        List<Flat> database = new List<Flat>();
        public uint GetLastElementId => database.Count == 0 ? 0 : database.Last().id;
        public void AddFlat(Flat flat)
        {
            database.Add(flat);
            NotifyFlatAdded?.Invoke("New flat was added");
        }
        public void DeleteFlat(int id)
        {
            Flat temp = database.Find(item => item.id == id);
            database.Remove(temp);
            NotifyFlatDeleted?.Invoke("Flat was deleted");
        }

        public void UpdatePrice(int id, float price)
        {
            Flat temp = database.Find(item => item.id == id);
            temp.price = price;
            NotifyFlatUpdatedPrice?.Invoke("Price was changed");
        }

        public void UpdateAddress(int id, string address)
        {
            Flat temp = database.Find(item => item.id == id);
            temp.address = address;
            NotifyFlatUpdatedAddress?.Invoke("Address was changed");
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

        private string GetFlatInfo(Flat flat)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("ID: ").AppendLine(flat.id.ToString());
            sb.Append("Rooms: ").AppendLine(flat.rooms.ToString());
            sb.Append("Price: ").AppendLine(flat.price.ToString());
            sb.Append("Address: ").AppendLine(flat.address);
            sb.AppendLine();
            return sb.ToString();
        }

        public string GetFullInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var flat in database)
            {
                sb.Append(GetFlatInfo(flat));
            }
            return sb.ToString();
        }

    }
}
