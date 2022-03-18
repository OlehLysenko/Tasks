using System;
using System.Collections.Generic;

namespace TestParking
{
    class Program
    {
        static void AddCar(List<Car> cars)
        {
                Console.WriteLine(" Добавлена машина");
                cars.Add(new Car());
                Console.WriteLine($"\tМашина {cars[^1].ModelCar}\t|  Год изготовления: {cars[^1].YearCar}\t|  Время вьезда: {cars[^1].ParkingTimeIn}");
        }
        static void GaragePlaces(List<Car> cars, int content)
        {
            Console.WriteLine("\t Места в гараже:");
            foreach (var car in cars)
            {
                Console.WriteLine($"\tМашина {car.ModelCar}\t|  Год изготовления: {car.YearCar}\t|  Время вьезда: {car.ParkingTimeIn}");
            }
            for (int i = cars.Count; i < content; i++)
            {
                Console.WriteLine("\tСвободное место " + (i + 1));
            }
        }
        static void RemoveCar(List<Car> cars, double costpermin)
        {
            Console.Write(" Укажите парковочное место машины, которую хотите забрать:");
            int index = Convert.ToInt32(Console.ReadLine());
            Console.Write($"Время въезда машины: {cars[index - 1].ParkingTimeIn} \nВремя выезда машины: {cars[index - 1].ParkingTimeOut}");
            double pay = (cars[index - 1].ParkingTimeOut.Minute - cars[index - 1].ParkingTimeIn.Minute) * costpermin;
            Console.WriteLine($"\nСумма к оплате за парковку: {pay} грн");
            cars.Remove(cars[index - 1]);
        }
        static void Main()
        {
            int content;
            double costpermin;
            Console.WriteLine("Добро пожаловать в конструктор паркинга.");
            Console.Write("Введите вместимость гаража: ");
            try
            {
                content = Convert.ToInt32(Console.ReadLine()); //N
            } 
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка при конвертации. Введите целое число");
                content = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Введите стоимость парковки в минуту: ");
            try
            {
                 costpermin = Single.Parse(Console.ReadLine()); //K
            }
            catch (FormatException)
            {
                Console.WriteLine("\nОшибка при конвертации. Введите число");
                costpermin = Single.Parse(Console.ReadLine());
            }
            bool menu = true;
            List<Car> cars = new List<Car>();
            while (menu)
            {
                Console.WriteLine("\nДоступные команды: " +
                        "\n\t1. Добавить машину " +
                        "\n\t2. Проверить свободные места " +
                        "\n\t3. Рассчитать и забрать  машину " +
                        "\n\tEsc - выход, Del - очистка " +
                        "\n\t Выбери команду \n");
                ConsoleKey consoleKey = Console.ReadKey().Key;
                switch (consoleKey)
                {
                    case ConsoleKey.D1:
                    case ConsoleKey.NumPad1:
                        if (cars.Count < content)
                        {
                            AddCar(cars);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(" Гараж переполнен. Ждите освободится парковочное место");
                            break;
                        }
                    case ConsoleKey.D2:
                    case ConsoleKey.NumPad2:
                        GaragePlaces(cars, content);
                        break;
                    case ConsoleKey.D3:
                    case ConsoleKey.NumPad3:
                        RemoveCar(cars, costpermin);
                        break;
                    case ConsoleKey.Escape:
                        menu = false;
                        break;
                    case ConsoleKey.Delete:
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("\tНеверный символ");
                        break;
                }
            }
        }        
    }
}
