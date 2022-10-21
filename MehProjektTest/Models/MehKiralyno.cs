using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.CodeDom;
using MehProjektTest.Helpers;

namespace MehProjektTest.Models
{

    public class MehKiralyno : Meh
    {


        #region BasicPros
        //basic tulajdonságok
        public double Termekenyseg { get; set; }
        public int MaxSpawnCap { get; private set; }
        public int MaxSpawnTilRe { get; set; }
        //public double Aggresszio { get; set; }
        //public double Egeszseg { get; set; }
        //public double Tomeg { get; set; }
        //public double Sebesseg { get; set; }
        //public double Kapacitas { get; set; }
        //public double Hatekonysag { get; set; }
        //public double Eszleles { get; set; }
        #endregion

        #region HelperProps
        public bool IsSpawnPauesed=false;
        public int cdtimer = 0;
        #endregion


        public MehKiralyno(MehKiralyno mehKiralyno) : base(mehKiralyno)
        {
            if (mehKiralyno != null)
            {
                Termekenyseg = mehKiralyno.Termekenyseg * (_minevo + Utility.rnd.NextDouble() / _modifier);
                MaxSpawnCap = Convert.ToInt32(mehKiralyno.MaxSpawnCap * (_minevo + Utility.rnd.NextDouble() / _modifier));
                MaxSpawnTilRe = 100;
            }
            else
            {
                Termekenyseg = 10;
                MaxSpawnTilRe = 100;
                MaxSpawnCap = 1000;
            }            

        }


        public void Spawning(Kaptar myKaptar)
        {
            if (IsSpawnPauesed)
            {
                cdtimer--;
                if (cdtimer == 0)
                {
                    IsSpawnPauesed = false;
                    MaxSpawnTilRe = MaxSpawnCap;
                }
                
            }
            else
            {
                for (int i = 0; i < Termekenyseg; i++)
                {
                    myKaptar.Mehek.Add(new Meh(this));
                    MaxSpawnTilRe--;
                    if (MaxSpawnTilRe==0)
                    {
                        SpawnRefresh();
                        return;
                    }
                }
            }
        }
        public void SpawnRefresh()
        {
            IsSpawnPauesed = true;
            cdtimer = 2;

        }

    }
}
