using MehProjektTest.Helpers;
using MehProjektTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MehProjektTest.Logic
{
    public class TurnLogics
    {
        public static List<Kaptar> OsszesKaptar = new List<Kaptar>();

        private int roundCl = 0;
        private int MaxRound = 500;
        public void DivideCheck()
        {
            foreach (var item in OsszesKaptar.ToList())
            {
                if (item.Mehek.Count > 1000)
                {
                    
                    MehKiralyno newQueen = new MehKiralyno(item.Kiralyno); // egy sima méhből nevelnek méhkirálynőt
                    OsszesKaptar.Add(new Kaptar(newQueen));
                    int rndCount = Utility.rnd.Next(300,400);
                    for (int i = 0; i < rndCount; i++)
                    {
                        OsszesKaptar.Last().Mehek.Add(item.Mehek[i]);
                        item.Mehek.Remove(item.Mehek[i]);
                    }
                }
            }
        }
        async public void Start()
        {
            Task t = new Task(() =>
            {
                while (roundCl<MaxRound)
                {
                    foreach (var item in OsszesKaptar)
                    {
                        item.Kiralyno.Spawning(item);
                        
                    }
                    DivideCheck();


                    Thread.Sleep(20);
                }
            });
            t.Start();
        }


    }
}
