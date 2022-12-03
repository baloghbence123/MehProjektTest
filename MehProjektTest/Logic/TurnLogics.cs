using MehProjektTest.Helpers;
using MehProjektTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MehProjektTest.Logic
{
    public class TurnLogics
    {
        public static List<Kaptar> OsszesKaptar = new List<Kaptar>();

        public int roundCl = 0;
        public int MaxRound = 1000000;

        public void Clearing(Kaptar item)
        {
            if (item.Mehek.Count<1)
            {
                OsszesKaptar.Remove(item);
            }
        }
        public void RoundSkeleton()
        {
            foreach (var item in OsszesKaptar.ToList()) //allkaptar check
            {
                item.Kiralyno.Spawning(item);
                DivideCheck(item);
                if (roundCl>30)
                {
                 Eating(item);
                }
                Aging(item);
                FoodSourcing(item);
                Clearing(item);
            }
           
        }
        public void DivideCheck(Kaptar item)
        {
            if (item.Mehek.Count > 1000)  //ha egy kaptárban több mint 1000 méh van akkor megrajzik kevesebb mint 500 méh
            {

                MehKiralyno newQueen = new MehKiralyno(item.Kiralyno); // egy sima méhből nevelnek méhkirálynőt
                OsszesKaptar.Add(new Kaptar(newQueen));
                var tmpKapt = OsszesKaptar.FirstOrDefault(t => t.Kiralyno == newQueen); //Megtaláljuk az új kaptárat
                int rndCount = Utility.rnd.Next(200, 500);
                for (int i = 0; i < rndCount; i++)
                {
                    int rndctr = Utility.rnd.Next(item.Mehek.Count);

                    tmpKapt.Mehek.Add(item.Mehek[rndctr]);
                    item.Mehek.Remove(item.Mehek[rndctr]);
                }
            }
        }
        public void Eating(Kaptar item)
        {

            double tmpctr = item.elelem - (item.Mehek.Count * 0.5f);

            if (tmpctr < 0)
            {
                
                item.elelem = 0;
                //meghal annyi méh amennyinek nem jutott élelem
                for (int i = 0; i < Math.Abs(tmpctr) * 10; i++)
                {
                    if (item.Mehek.Count>0)
                    {
                        item.Mehek.RemoveRange(Utility.rnd.Next(item.Mehek.Count), 1);
                    }
                }
            }
            else
            {
                item.elelem = tmpctr;
            }
            ;

        }
        public void Aging(Kaptar item)
        {

            foreach(var egyed in item.Mehek.ToList())
            {
                //age check
                int rndWheelSpin = Utility.rnd.Next(100);
                if (AgingCalculator.Chance((int)egyed.Age) > rndWheelSpin)
                {
                    item.Mehek.Remove(egyed);
                }
                egyed.AgePlus();
            }



        }

        public void FoodSourcing(Kaptar item)
        {
            foreach (var egyed in item.Mehek.ToList())
            {
                if (egyed.Role==Role.Dolgozo)
                {
                    if (item.MaxElelem> item.elelem)
                    {
                        item.elelem += egyed.Kapacitas * egyed.Hatekonysag * egyed.Sebesseg * (1 / egyed.Tomeg) * egyed.Eszleles;
                    }
                    
                    ;
                }
                ;
            }
            
        }





















        async public void Start()
        {
            Task t = new Task(() =>
            {
                while (roundCl < MaxRound)
                {
                    RoundSkeleton();
                    roundCl++;

                    Thread.Sleep(200);
                }
            });
            t.Start();
        }

    }
    
}
