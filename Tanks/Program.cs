using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyClassLib;
using MyClassLib.WorldOfTanks;
namespace Tanks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("              Добро пожаловать в Parimatch -  " +
                "играют они выигрываете вы");
            const int countWar = 5;
            const int countPropertyTank = 3;
            string Tank1Name = "T-34";
            string Tank2Name = "Pantera";
            int NumberTank = 0;
            bool isNum = false;
            int money = 0;
            int sum1 = 0, sum2 = 0;
            Tank[] tank1 = new Tank[countWar];
            Tank[] tank2 = new Tank[countWar];
            while (!isNum)
            {
            Console.WriteLine("Напишите номер танка за которого будете болеть  " +
                " №1 = "+Tank1Name+"  №2 = "+Tank2Name+" № 0 = "+"Ничья(шанс маленький)");
                isNum=Tank.IsNumber(Console.ReadLine(),ref NumberTank);
                if (NumberTank>2 || NumberTank<0) isNum = false;
            }
            isNum = false;
            while (!isNum)
            {
            Console.WriteLine("Введите сумму ставки ");
                isNum = Tank.IsNumber(Console.ReadLine(), ref money);
                if (money < 1) isNum = false;
            }
            isNum = false;

            Random[] rnd = new Random[countPropertyTank];
            int[] arrayRand = new int[countPropertyTank];
            for (int i = 0; i < countPropertyTank; i++)
                rnd[i] = new Random();
            Console.WriteLine("Чтобы продолжить битву нажмите любую кнопку");

            for (int i = 0; i < countWar; i++)
            {
                for (int j = 0; j < countPropertyTank; j++)
                    arrayRand[j]= rnd[j].Next(0, 100);
                try
                {
                    tank1[i] = new Tank(arrayRand[0], arrayRand[1], arrayRand[2], Tank1Name);
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                    i--;
                    continue;
                }
                for (int j = 0; j < countPropertyTank; j++)
                    arrayRand[j] = rnd[j].Next(0, 100);
                try
                {
                    tank2[i] = new Tank(arrayRand[0], arrayRand[1], arrayRand[2], Tank2Name);
                }
                catch(Exception e) {
                    Console.WriteLine(e.Message);
                    i--;
                    continue;
                }
                Console.Write("Поединок № " + (i+1)+" :  ");
                if ((tank1[i] ^ tank2[i]) == 1)
                {
                    Console.WriteLine(tank1[i].Name + " победил ");
                    sum1++;
                }
                else if ((tank1[i] ^ tank2[i]) == 2)
                {
                    Console.WriteLine(tank2[i].Name + " победил ");
                    sum2++;
                }
                else if ((tank1[i] ^ tank2[i]) == 0)
                {
                    Console.WriteLine("Дружба победилa!");
                }
                Console.ReadKey();
            }
            if((NumberTank==1 && (sum1 > sum2)) || (NumberTank==2) && (sum2>sum1)
                ||(NumberTank==0 && sum1==sum2))
            {
                Console.WriteLine("Вы выйграли "+(2*money)+"$");
            }
            else
            {
                Console.WriteLine("Вы проиграли,в след. раз получится ");
            }
        }
    }
}
