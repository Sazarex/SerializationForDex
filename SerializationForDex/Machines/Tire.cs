using System;
using System.Collections.Generic;
using System.Text;

namespace SerializationForDex.Machines
{
    enum Season
    {
        Winter,
        Summer
    }
    class Tire
    {
        public string Company { get; set; }
        public Season Season { get; set; }

        public Tire(string company, Season season)
        {
            Company = company;
            Season = season;
        }
    }
}
