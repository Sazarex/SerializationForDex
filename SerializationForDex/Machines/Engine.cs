using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationForDex.Machines
{
        class Engine
        {
            public string Title { get; set; }
            public int HorseForces { get; set; }

            public Engine(string title, int horseForces)
            {
                Title = title;
                HorseForces = horseForces;
            }
        }
}
