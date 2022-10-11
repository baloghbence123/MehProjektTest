using MehProjektTest.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MehProjektTest.Models
{
    public class Meh : IMeh
    {
        internal const int _modifier = 5;
        internal const double _minevo = 0.9;

        public static int _id = 0;
        public int Id { get; private set; }
        public int CsaladId { get; private set; }


        MehKiralyno Anya;

        
        public double Age { get; private set; }
        public double Aggresszio { get; set; }
        public double Egeszseg { get; set; }
        public double Tomeg { get; set; }
        public double Sebesseg { get; set; }
        public double Kapacitas { get; set; }
        public double Hatekonysag { get; set; }
        public double Eszleles { get; set; }


        public Meh(MehKiralyno mehKiralyno)
        {
            Id = _id++;
            Age = 0;
            this.Anya = mehKiralyno;

            var properties = typeof(Meh).GetProperties();
            ;
            if (Anya != null)
            {
                
                foreach (var prop in properties)
                {
                    if (prop.PropertyType == typeof(double)&& prop!=typeof(Meh).GetProperty("Age"))
                    {
                        prop.SetValue(this, (double)prop.GetValue(this.Anya) * (_minevo + (Utility.rnd.NextDouble() / _modifier)));
                    }
                    
                    else if (prop.PropertyType == typeof(int) && prop!=typeof(Meh).GetProperty("Id"))
                    {

                        prop.SetValue(this, Convert.ToInt32((int)prop.GetValue(this.Anya) * (_minevo + (Utility.rnd.NextDouble() / _modifier))));
                    }
                    ;
                    CsaladId = mehKiralyno.Id;
                }
            }
            else
            {
                
                foreach (var item in properties)
                {
                    if (item.CanWrite&& item != typeof(Meh).GetProperty("Id") && item != typeof(Meh).GetProperty("Age"))
                        item.SetValue(this, 1);
                }
                CsaladId = this.Id;
            }
        }
        public Meh()
        {

        }

        public Meh DeepCopy()
        {
            Meh tmp = new Meh();
            var props = typeof(Meh).GetProperties();
            foreach (var item in props)
            {
                item.SetValue(tmp, item.GetValue(this));
            }
            return tmp;
        }

        public void Divide()
        {

        }


    }
}
