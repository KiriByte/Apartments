using System.Text;
namespace Apartments
{
    internal class Program
    {
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