using MehProjektTest.Helpers;
using System;
using System.Data;
using System.Runtime.Remoting.Messaging;

namespace MehProjektTest.Models
{
    public enum Role
    {
        Dajka,Epito,Termelo, Dolgozo, Or, 
    }
    public class Meh : IMeh
    {
        internal const int _modifier = 3;
        internal const double _minevo = 0.9;

        public static int _id = 0;
        public int Id { get; private set; }
        public int CsaladId { get; private set; }


        MehKiralyno Anya;


        public double Age { get; private set; } //nap
        public double Aggresszio { get; set; }
        public double Egeszseg { get; set; }
        public double Tomeg { get; set; }
        public double Kapacitas { get; set; }
        public double Sebesseg { get; set; }
        public double Hatekonysag { get; set; }
        public double Eszleles { get; set; }

        public Role Role
        {
            get
            {
                if (Age < 4)
                {
                    return Role.Dajka;
                    ;
                }
                else if (Age < 10)
                {
                    return Role.Epito;
                    ;
                }
                else if (Age < 16)
                {
                    return Role.Termelo;
                }
                else if (Age < 80)
                {
                    return Role.Dolgozo;
                    ;
                }
                else
                {
                    return Role.Or;
                }

            }

        }


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
                    if (prop.PropertyType == typeof(double) && prop != typeof(Meh).GetProperty("Age"))
                    {
                        prop.SetValue(this, (double)prop.GetValue(this.Anya) * (_minevo + (Utility.rnd.NextDouble() / _modifier)));
                    }

                    else if (prop.PropertyType == typeof(int) && prop != typeof(Meh).GetProperty("Id"))
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
                    if (item.CanWrite && item != typeof(Meh).GetProperty("Id") && item != typeof(Meh).GetProperty("Age"))
                        item.SetValue(this, 1);
                }
                CsaladId = this.Id;
            }
            ;
        }
        public Meh()
        {

        }
        public void AgePlus()
        {
            Age++;
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
