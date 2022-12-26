using System.Text;
namespace Apartments
{
    internal class Program
    {
        public class Flat
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
        public class DataBase
        {
            List<Flat> database = new List<Flat>();

            //public uint GetLastElementId => database.Last().id;
            public uint GetLastElementId
            {
                get
                {
                    if (database.Count == 0) return 0;
                    else return database.Last().id;
                }
            }


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
                float srednee = 0;
                foreach (Flat item in database)
                {
                    srednee += item.price;
                }
                return srednee /= database.Count;
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

            public void Test()
            {

            }
        }
        static void Main(string[] args)
        {
            DataBase data = new DataBase();
            data.AddFlat(new Flat(data.GetLastElementId + 1, 1, 12, "Hrodna, Sovetskaya 25-1"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 2, 15, "Vitebsk, Oktyabrskaya 53-5"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 3, 16, "Gomel, Krasnaarmeyskaya 24-1"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 4, 17, "Minsk, Gvardeyskaya 14-51"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 5, 18, "Brest, Lenina 1-34"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 6, 19, "derevnya Vasuki, Pobeda 1-1"));

            data.UpdatePrice(2, 5000);
            data.UpdateAdress(1, "Lida, Fursenko 5-1");

            Console.WriteLine(data.GetFullInfo());
        }
    }
}