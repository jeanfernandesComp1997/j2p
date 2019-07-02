using j2p.Domain.Entities.Base;
using System.Collections.Generic;

namespace j2p.Domain.Entities
{
    public class Local : EntityBase
    {
        public string Country { get; protected set; }

        public string State { get; protected set; }

        public string City { get; protected set; }

        public string Cep { get; protected set; }

        public string Street { get; protected set; }

        public string Number { get; protected set; }

        public string Complement { get; protected set; }

        public string Phone { get; protected set; }

        public string Type { get; protected set; }

        public Owner Owner { get; protected set; }

        public List<Event> Events { get; protected set; }

        protected Local()
        {

        }

        public Local(string country, string state, string city, string cep, string street, string number, string complement, string phone, string type, Owner owner, List<Event> events)
        {
            Country = country;
            State = country;
            City = city;
            Cep = country;
            Street = street;
            Number = number;
            Complement = complement;
            Phone = phone;
            Type = type;
            Owner = owner;
        }
    }
}
