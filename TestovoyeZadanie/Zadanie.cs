using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestovoyeZadanie
{
    class Zadanie
    {
        static string[] doors = new string[] {"Автомобиль", "Коза", "Коза" };

        static void Main(string[] args)
        {
            GameModel(1000);

            Console.ReadLine();
        }

        static int[] PickingADoor(int NumberOfRepeats) //Выбор двери участником
        {
            Random PickADoor = new Random();

            int[] DoorPicked = new int[NumberOfRepeats];

            for (int i = 0; i < NumberOfRepeats; i++)
            {
                DoorPicked[i] = PickADoor.Next(3);
            }
            return DoorPicked;
        }

        static int HostOpeningAnotherDoor(int DoorPicked) //Открытие одной из оставшихся дверей ведущим
        {
            var DoorOpened = 0;

            for (int i = 0; i < doors.GetLength(0); i++)
            {
                if (doors[i] != "Автомобиль")
                {
                    if (i != DoorPicked)
                    {
                        DoorOpened = i;
                        break;
                    }
                }
            }

            return DoorOpened;
        }

        static void GameModel(int NumberOfRepeats) //Генерация модели игры
        {
            var DoorPicked = PickingADoor(NumberOfRepeats);



            int[] DecisionChanged = { 0, 0 };

            int[] DecisionNotChanged = { 0, 0 };



            for (int i = 0; i < NumberOfRepeats; i++) //Игрок не меняет своего решения
            {
                if (doors[DoorPicked[i]] == "Автомобиль")
                {
                    DecisionNotChanged[1] += 1;
                }
                else
                {
                    DecisionNotChanged[0] += 1;
                }
            }



            for (int i = 0; i < NumberOfRepeats; i++) //Игрок меняет своё решение
            {

                int NewDoorPicked = DoorPicked[i];

                var DoorOpenedByHost = HostOpeningAnotherDoor(DoorPicked[i]);

                for (int j = 0; j < doors.GetLength(0); j++)
                {
                    if (j != DoorPicked[i])
                    {
                        if (j != DoorOpenedByHost)
                        {
                            NewDoorPicked = j;
                        }
                    }
                }

                if (doors[NewDoorPicked] == "Автомобиль")
                {
                    DecisionChanged[1] += 1;
                }
                else
                {
                    DecisionChanged[0] += 1;
                }
            }

            Console.WriteLine("Игрок изменил свой выбор");
            Console.Write("Побед: ");
            Console.WriteLine(DecisionChanged[1].ToString());
            Console.Write("Проигрышей: ");
            Console.WriteLine(DecisionChanged[0].ToString());
            Console.WriteLine();
            Console.WriteLine("Игрок не менял свего выбора");
            Console.Write("Побед: ");
            Console.WriteLine(DecisionNotChanged[1].ToString());
            Console.Write("Проигрышей: ");
            Console.WriteLine(DecisionNotChanged[0].ToString());
        }
    }
}
