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
        
        
        
        List<Meh> mehs = new List<Meh>();

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
        public MehKiralyno(MehKiralyno mehKiralyno) :base(mehKiralyno)
        {
            if (mehKiralyno!=null)
            {
                Termekenyseg = mehKiralyno.Termekenyseg * (_minevo + Utility.rnd.NextDouble() / _modifier);
                MaxSpawnCap = Convert.ToInt32(mehKiralyno.MaxSpawnCap * (_minevo + Utility.rnd.NextDouble() / _modifier));
                MaxSpawnTilRe = 0;
            }
            else
            {
                Termekenyseg = 1;
                MaxSpawnTilRe = 0;
                MaxSpawnCap = 1000;
            }

        }

        public void Spawning()
        {
            
        }

    }
}
