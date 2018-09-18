using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyClassLib
{
    namespace WorldOfTanks
    {
        public class Tank
        {
            public int Reservation { get; set; }
            public int Ammunition { get; set; }
            public int Maneuverability { get; set; }
            public string Name{ get;set;}
            public Tank() {
                Reservation = 0;
                Ammunition = 0;
                Maneuverability = 0;
            }
            public Tank(int reservation,int ammunition,int maneuverability,string name)
            {
                if (reservation > 100 || ammunition > 100 || maneuverability > 100)
                {
                    throw new Exception("Превышает 100%");
                }
                else if (reservation < 0 || ammunition < 0 || maneuverability < 0)
                {
                    throw new Exception("Меньше 0%");
                }
                else if (name.Length == 0) throw new Exception("Название танка пустой ");
                Reservation = reservation;
                Ammunition = ammunition;
                Maneuverability = maneuverability;
                Name = name;
            }
            public static int  operator ^ (Tank t1,Tank t2)
            {
                int sum1 = 0, sum2 = 0;
                if (t1.Reservation > t2.Reservation) sum1++;
                else if (t1.Reservation < t2.Reservation) sum2++;
                if (t1.Ammunition > t2.Ammunition) sum1++;
                else if (t1.Ammunition < t2.Ammunition) sum2++;
                if (t1.Maneuverability > t2.Maneuverability) sum1++;
                else if (t1.Maneuverability < t2.Maneuverability) sum2++;
                if (sum1 > sum2) return 1;
                else if (sum1 < sum2) return 2;
                return 0;
            }
            public static bool IsNumber(string numberAsString, ref int number)
            {
                try
                {
                    number = int.Parse(numberAsString);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }
    }
}
