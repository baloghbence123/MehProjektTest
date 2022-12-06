using System.Collections.Generic;

namespace MehProjektTest.Models
{
    public class Kaptar
    {

        public MehKiralyno Kiralyno;
        public List<Meh> Mehek = new List<Meh>();

        public int kaptarId;

        public double Allapot { get; set; } //max 100 lehet a kaptár állapota

        public double MaxElelem { get => Allapot * 100; }
        public double elelem { get; set; } //a jelenlegi élelelm



        public Kaptar(MehKiralyno newQ)
        {
            Kiralyno = newQ;
            kaptarId = newQ.Id;
            elelem = 565;
            Allapot = 50;

        }

    }
}
