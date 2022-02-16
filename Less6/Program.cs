using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Less6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Список текущеих процессов Windows: " + Environment.NewLine);

            Process[] myProcesses = Process.GetProcesses();


            foreach (var item in myProcesses)
            {
                try
                {
                    Console.WriteLine(item.Id + GetProbel(Convert.ToString(item.Id).Length, myProcesses.Select(x => x.Id).ToArray().Select(k => Convert.ToString(k).Length).Max()) + item.ProcessName + GetProbel(item.ProcessName.Length, myProcesses.Select(x => x.ProcessName).ToArray().Select(k => k.Length).Max()) + item.StartTime);
                }
                catch (Exception exception)
                {
                    Console.WriteLine(item.Id + GetProbel(Convert.ToString(item.Id).Length, myProcesses.Select(x => x.Id).ToArray().Select(k => Convert.ToString(k).Length).Max()) + item.ProcessName + GetProbel(item.ProcessName.Length, myProcesses.Select(x => x.ProcessName).ToArray().Select(k => k.Length).Max()) + "no data: " + exception.Message);
                }

            }


            Console.WriteLine(Environment.NewLine + Environment.NewLine);
            Boolean isDoing = false;
            var mySelectKey = 0;

            do
            {
                Console.WriteLine("Что хотим сделать?");
                Console.WriteLine("1 - Создать процесс");
                Console.WriteLine("2 - Завершить процесс");
                Console.WriteLine("0 - Выйти" + Environment.NewLine + Environment.NewLine);

                var key = Console.ReadKey();

                if ((key.KeyChar != 49) && (key.KeyChar != 50) && (key.KeyChar != 48))
                {
                    Console.WriteLine(Environment.NewLine);
                    Console.WriteLine("Введен не допустимый символ" + Environment.NewLine + Environment.NewLine);
                }
                else
                {
                    Console.WriteLine(Environment.NewLine);
                    mySelectKey = Convert.ToInt32(key.KeyChar);
                    isDoing = true;
                }
            } while (isDoing == false);


            switch (mySelectKey)
            {
                //выход из программы
                case 48:
                    {
                        Console.WriteLine("Очень жаль");
                    }
                    break;
                //создаем процесса
                case 49:
                    {
                        Console.WriteLine("Напишите имя процесса, который вы хотите создать" + Environment.NewLine);
                        string nameProcess = Console.ReadLine();
                        try
                        {
                            Process.Start(nameProcess);
                            Console.WriteLine("Мои поздравления! Вы удачно создали процесс (" + nameProcess + ")");
                        }
                        catch (Exception exception)
                        {
                            Console.WriteLine("Упс. Что-то пошло не так, возникла ошибка при  создании процесса: " + exception.Message);
                        }
                    }
                    break;
                //удаляем процесс
                case 50:
                    {
                        do
                        {
                            Console.WriteLine("Как хотим завершить процесс?");
                            Console.WriteLine("1 - Удалить по ID");
                            Console.WriteLine("2 - Удалить по имени");
                            Console.WriteLine("0 - Выйти" + Environment.NewLine + Environment.NewLine);

                            var key = Console.ReadKey();

                            if ((key.KeyChar != 49) && (key.KeyChar != 50) && (key.KeyChar != 48))
                            {
                                Console.WriteLine(Environment.NewLine);
                                Console.WriteLine("Введен не допустимый символ" + Environment.NewLine + Environment.NewLine);
                            }
                            else
                            {
                                Console.WriteLine(Environment.NewLine);
                                mySelectKey = Convert.ToInt32(key.KeyChar);
                                isDoing = true;
                            }
                        } while (isDoing == false);


                        switch (mySelectKey)
                        {
                            //выход из программы
                            case 48:
                                {
                                    Console.WriteLine("Очень жаль");
                                }
                                break;
                            //удаляем процесс по ID
                            case 49:
                                {
                                    Console.WriteLine("Напишите ID процесса, который вы хотите удалить" + Environment.NewLine);
                                    string nameProcess = Console.ReadLine();
                                    try
                                    {
                                        Process.GetProcessById(Convert.ToInt32(nameProcess)).Kill();
                                        Console.WriteLine("Мои поздравления! Процесс удачно завершен (" + nameProcess + ")");
                                    }
                                    catch (Exception exception)
                                    {
                                        Console.WriteLine("Упс. Что-то пошло не так, возникла ошибка при удалении процесса: " + exception.Message);
                                    }
                                }
                                break;
                            //удаляем процесс по имени
                            case 50:
                                {
                                    Console.WriteLine("Напишите имя процесса, который вы хотите удалить" + Environment.NewLine);
                                    string nameProcess = Console.ReadLine();
                                    try
                                    {
                                        foreach (var item in Process.GetProcessesByName(nameProcess))
                                        {
                                            item.Kill();
                                        }
                                        ;
                                        Console.WriteLine("Мои поздравления! Процесс(ы) удачно завершен (" + nameProcess + ")");
                                    }
                                    catch (Exception exception)
                                    {
                                        Console.WriteLine("Упс. Что-то пошло не так, возникла ошибка при удалении процесса: " + exception.Message);
                                    }
                                }
                                break;
                        }

                    }
                    break;
            }

            Console.ReadKey();
        }


        static string GetProbel(int len, int lenMax)
        {

            string probel = "   ";
            for (int i = len; i < lenMax; i++)
            {
                probel += " ";
            }

            return probel;
        }
    }
}
