using j2p.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
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

            new AddNotifications<Local>(this)
                .IfNullOrInvalidLength(x => x.Country, 2, 50, "O País é obrigatório e deve conter entre 2 e 50 caracteres.")
                .IfNullOrInvalidLength(x => x.State, 2, 2, "O Estado é obrigatório e deve conter 2 caracteres.")
                .IfNullOrInvalidLength(x => x.City, 2, 50, "A Cidade é obrigatória e deve conter entre 2 e 50 caracteres.")
                .IfNullOrInvalidLength(x => x.Cep, 9, 9, "O Cep é obrigatório e deve conter 9.")
                .IfNullOrInvalidLength(x => x.Street, 2, 50, "A Rua é obrigatória e deve conter entre 2 e 50 caracteres.")
                .IfNullOrInvalidLength(x => x.Number, 1, 50, "O Número é obrigatório e deve conter entre 1 e 50 caracteres.")
                .IfNullOrInvalidLength(x => x.Phone, 11, 15, "O Telefone é obrigatório e deve conter entre 11 e 15 caracteres.")
                .IfNullOrInvalidLength(x => x.Type, 4, 50, "O Tipo é obrigatório e deve conter entre 4 e 50 caracteres.");

            AddNotifications(owner);
        }
    }
}
