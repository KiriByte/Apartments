using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Apartments
{
    delegate void View(string message);
    internal class Program
    {
        static void ConsolePrint(string message) => Console.WriteLine(message);
        static void Main(string[] args)
        {
            DataBase data = new DataBase();
            View view = ConsolePrint;

            AddFollowersForAddFlat(data);
            AddFollowersForAllSubscribe(data);

            CreateNewDataBase(data);

            data.UpdatePrice(2, 5000);
            data.UpdateAddress(1, "Lida, Fursenko 5-1");
            view(data.GetFullInfo());
        }

        static void CreateNewDataBase(DataBase data)
        {
            data.AddFlat(new Flat(data.GetLastElementId + 1, 1, 12, "Hrodna, Sovetskaya 25-1"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 2, 15, "Vitebsk, Oktyabrskaya 53-5"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 3, 16, "Gomel, Krasnaarmeyskaya 24-1"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 4, 17, "Minsk, Gvardeyskaya 14-51"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 5, 18, "Brest, Lenina 1-34"));
            data.AddFlat(new Flat(data.GetLastElementId + 1, 6, 19, "derevnya Vasuki, Pobeda 1-1"));
        }

        static void AddFollowersForAddFlat(DataBase data)
        {
            List<INotifyFlatAdded> followersAddFlat = new List<INotifyFlatAdded>();
            followersAddFlat.Add(new Client("Jacob"));
            followersAddFlat.Add(new Client("Mike"));

            foreach (var follower in followersAddFlat)
            {
                data.NotifyFlatAdded += s => Console.WriteLine(follower.Notify(s));
            }
        }
        static void AddFollowersForAllSubscribe(DataBase data)
        {
            List<INotifyAll> followersAll = new List<INotifyAll>();
            followersAll.Add(new Realtor("Dima"));
            followersAll.Add(new Realtor("Alex"));
            foreach (var follower in followersAll)
            {
                data.NotifyFlatAdded += s => Console.WriteLine(follower.Notify(s));
                data.NotifyFlatDeleted += s => Console.WriteLine(follower.Notify(s));
                data.NotifyFlatUpdatedPrice += s => Console.WriteLine(follower.Notify(s));
                data.NotifyFlatUpdatedAddress += s => Console.WriteLine(follower.Notify(s));
            }
        }
    }
}