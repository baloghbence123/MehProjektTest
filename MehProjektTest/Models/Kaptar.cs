using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehProjektTest.Models
{
    public class Kaptar
    {
        
        public MehKiralyno Kiralyno;
        public List<Meh> Mehek = new List<Meh>();

        public int kaptarId;
        public int elelem;
        public Kaptar(MehKiralyno newQ)
        {
            Kiralyno = newQ;
            kaptarId = newQ.Id;
            elelem = 100;
        }

    }
}
