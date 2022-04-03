using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace SerializationForDex.Machines
{
    class Car : IMovable
    {
        public string Title { get; set; }
        public int MaxSpeed { get; set; }
        public float АccelerationToHundred { get; set; }
        public Engine EngineOfCar { get; set; }

        public Tire[] Tires { get; set; }

        public Car(string title, int maxSpeed, float acceleration, Engine engine, Tire[] tires)
        {
            Title = title;
            MaxSpeed = maxSpeed;
            АccelerationToHundred = acceleration;
            EngineOfCar = engine;
            Tires = tires;
        }

        public void Move()
        {
            Console.WriteLine("");
        }
    }
}
