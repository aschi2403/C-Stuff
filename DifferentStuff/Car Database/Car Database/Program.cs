using Car_Database.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Car_Database
{
    class Program
    {
        public static CarDataContext context = new CarDataContext();
        static void Main(string[] args)
        {
            

            
            context.CarMakes.AddRange(GetCarMakes());
            context.SaveChanges();
            context.CarModels.AddRange(GetCarModels());
            context.SaveChanges();
            context.People.AddRange(GetPeople());
            context.SaveChanges();
            Console.WriteLine("Data added");

            foreach (var carmake in context.CarMakes)
            {
                Console.WriteLine(context.Ownerships.Count(o => o.CarModel.CarMake == carmake));
            }

            foreach(var carmodel in context.CarModels)
            {
                if (carmodel.Ownerships.Count() == 0)
                    Console.WriteLine(carmodel);
            }
        }

        static List<Person> GetPeople()
        {
            string path = "data\\people.csv";
            var reader = new StreamReader(File.OpenRead(path));
            var lines = new List<string>();
            var people = new List<Person>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                lines.Add(line);
            }

            var random = new Random();
            var vehicleNumber = 5000;

            foreach (var line in lines)
            {
                var lineContent = line.Split(",");

                var person = new Person
                {
                    PersonId = int.Parse(lineContent[0]),
                    FirstName = lineContent[1],
                    LastName = lineContent[2]
                };

                
                var ownership = new Ownership
                {
                    CarModel = context.CarModels.Find(random.Next(1, 20)),
                    Person = person,
                    VehicleIdentificationNumber = vehicleNumber.ToString()
                };
                vehicleNumber++;

                person.Ownerships.Add(ownership);
                people.Add(person);
            }
            return people;
        }

        static List<CarMake> GetCarMakes()
        {
            string path = "data\\carmake.csv";
            var reader = new StreamReader(File.OpenRead(path));
            var lines = new List<string>();
            var people = new List<CarMake>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                lines.Add(line);
            }

            foreach (var line in lines)
            {
                var lineContent = line.Split(",");

                people.Add(new CarMake
                {
                    CarMakeId = int.Parse(lineContent[0]),
                    Make = lineContent[1]
                });
            }
            return people;
        }

        static List<CarModel> GetCarModels()
        {
            string path = "data\\carmodel.csv";
            var reader = new StreamReader(File.OpenRead(path));
            var lines = new List<string>();
            var people = new List<CarModel>();

            while (!reader.EndOfStream)
            {
                var line = reader.ReadLine();
                lines.Add(line);
            }

            foreach (var line in lines)
            {
                var lineContent = line.Split(",");
                var random = new Random();

                people.Add(new CarModel
                {
                    CarModelId = int.Parse(lineContent[0]),
                    Model = lineContent[1],
                    CarMake = context.CarMakes.Find(int.Parse(lineContent[2]))
                });
            }
            return people;
        }
    }
}
