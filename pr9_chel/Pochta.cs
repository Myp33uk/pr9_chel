using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr9_chel

{
    struct Pochta
    {a
        public Pochta(string city, string whom, string value, string street, int house, int flat)
        {
            City = city;
            Whom = whom;
            Value = value;
            Street = street;
            House = house;
            Flat = flat;
        }
        public string City { get; set; }
        public string Whom { get; set; }
        public string Value { get; set; }
        public string Street { get; set; }
        public int House { get; set; }
        public int Flat { get; set; }
    }
}
