using MehProjektTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MehProjektTest
{
    
    class Program
    {

        static void Main(string[] args)
        {
            MehKiralyno mehKiralyno = new MehKiralyno(null);
            MehKiralyno mehKiralyno1 = new MehKiralyno(mehKiralyno) ;
            MehKiralyno mehKiralyno2 = new MehKiralyno(mehKiralyno);
            Meh bela = new Meh(mehKiralyno2);
            bela = mehKiralyno.DeepCopy();
            bela.Sebesseg = 15;











            ;
        }
    }
}
