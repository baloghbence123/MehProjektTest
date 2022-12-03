using MehProjektTest.Logic;
using MehProjektTest.Models;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MehProjektTest
{

    class Program
    {

        static void Main(string[] args)
        {
            MehKiralyno mehKiralyno = new MehKiralyno(null);
            TurnLogics tl = new TurnLogics();
            TurnLogics.OsszesKaptar.Add(new Kaptar(mehKiralyno));

            tl.Start();


            Task t = new Task(() =>
            {
                while (true)
                {
                    Console.WriteLine("Actual round: " + tl.roundCl);
                    foreach (var item in TurnLogics.OsszesKaptar.ToList())
                    {
                        Console.WriteLine("Kaptár ID: " + item.kaptarId + " | Összes méh a kaptárban: " + item.Mehek.Count + " | Élelem: "+item.elelem);

                    }
                    Thread.Sleep(300);
                    Console.Clear();
                }
            });

            t.Start();



            Console.ReadLine();

            ;
        }

    }
}
