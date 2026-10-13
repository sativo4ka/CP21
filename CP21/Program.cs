using System;

namespace CP21
{
    public class Vehicle
    {
    }

    public class Car : Vehicle
    {
    }

    public delegate TVehicle VehicleProducer<out TVehicle>();

    public delegate void VehicleConsumer<in TVehicle>(TVehicle vehicle);

    public class Program
    {
        public static Car GetCar() => new Car();

        public static void ProcessVehicle(Vehicle vehicle)
        {
            Console.WriteLine($"Обработано транспортное средство: {vehicle.GetType().Name}");
        }

        public static void Main()
        {
            Console.WriteLine("Проверка ковариантности:");
            VehicleProducer<Vehicle> p = GetCar;
            Vehicle vehicle = p();
            Console.WriteLine($"Метод GetCar вернул объект {vehicle.GetType().Name} как Vehicle.");

            Console.WriteLine("\nПроверка контравариантности:");
            VehicleConsumer<Car> c = ProcessVehicle;
            c(new Car());

            Console.WriteLine("\nПроверка завершена.");
        }
    }
}