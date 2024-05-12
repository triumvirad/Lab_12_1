using System;
using System.Linq.Expressions;
using System.Net.NetworkInformation;
using System.Runtime.Intrinsics.X86;
using System.Security.AccessControl;
using ClassLibrary;
namespace Lab_12_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MyList<MusicalInstrument> list = new MyList<MusicalInstrument>();
            MyList<MusicalInstrument> newList = new MyList<MusicalInstrument>();
            int answer = 1;
            while (answer != 11)
            {
                try
                {
                    Commands();
                    answer = int.Parse(Console.ReadLine());
                    switch (answer)
                    {
                        case 1:
                            Console.WriteLine("Введите размер коллекции:");
                            int size = int.Parse(Console.ReadLine());
                            list = new MyList<MusicalInstrument>(size);
                            Console.WriteLine("Коллекция создана.");
                            break;

                        case 2:
                            list.PrintList();
                            break;

                        case 3:
                            MusicalInstrument muz1 = new MusicalInstrument();
                            muz1.RandomInit();
                            list.AddToBegin(muz1);
                            Console.WriteLine("Элемент добавлен в начало.");
                            break;

                        case 4:
                            MusicalInstrument muz2 = new MusicalInstrument();
                            muz2.RandomInit();
                            list.AddToEnd(muz2);
                            Console.WriteLine("Элемент добавлен в конец.");
                            break;

                        case 5:
                            MusicalInstrument muz3 = new MusicalInstrument();
                            muz3.Init();
                            if (!list.RemoveItem(muz3)) Console.WriteLine("Элемент не найден.");
                            else Console.WriteLine("Элемент удалён.");
                            break;

                        case 6:
                            list.AddByPlace();
                            break;

                        case 7:
                            MusicalInstrument muzQ = new MusicalInstrument();
                            muzQ.Init();
                            list.RemoveItem2(muzQ);
                            break;

                        case 8:
                            newList = list.CloneList();
                            Console.WriteLine("Список скопирован.");
                            break;

                        case 9:
                            newList.PrintList();
                            break;

                        case 10:
                            list.ClearList();
                            Console.WriteLine("Список удалён из памяти.");
                            break;

                        case 11:
                            Console.WriteLine("Change da world. My final massege. Goodbye.");
                            break;

                        default:
                            Console.WriteLine();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }

        private static void Commands()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Меню.\n" +
                              "----------------------------------------------------------------------------\n" +
                              "1. Создать список.\n" +
                              "2. Распечатать список.\n" +
                              "3. Добавить элемент в начало списка. \n" +
                              "4. Добавить элемент в конец списка. \n" +
                              "5. Удалить элемент в списке.\n" +
                              "6. Добавить в список новые элементы на нечётные позиции. \n" +
                              "7. Удалить все элементы, начиная с элемента с заданным информационным полем.\n" +
                              "8. Скопировать список.\n" +
                              "9. Распечатать скопированный список. \n" +
                              "10. Удвлить список из памяти.\n" +
                              "11. Завершение работы.\n" +
                              "----------------------------------------------------------------------------\n");
        }
    }
}