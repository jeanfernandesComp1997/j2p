using j2p.Domain.Entities.Base;
using j2p.Domain.Enum;
using System.Collections.Generic;

namespace j2p.Domain.Entities
{
    public class Local : EntityBase
    {
        public virtual string Country { get; protected set; }

        public virtual string State { get; protected set; }

        public virtual string City { get; protected set; }

        public virtual string Cep { get; protected set; }

        public virtual string Street { get; protected set; }

        public virtual string Number { get; protected set; }

        public virtual string Complement { get; protected set; }

        public virtual string Phone { get; protected set; }

        public virtual EnumType Type { get; protected set; }

        public virtual Player Owner { get; protected set; }

        protected Local()
        {

        }

        public Local(string country, string state, string city, string cep, string street, string number, string complement, string phone, EnumType type, Player owner)
        {
            Country = country;
            State = state;
            City = city;
            Cep = cep;
            Street = street;
            Number = number;
            Complement = complement;
            Phone = phone;
            Type = type;
            Owner = owner;
        }

        public override void Validate()
        {
            if (string.IsNullOrEmpty(this.Country))
                _errors.AppendLine("País inválido.");

            if (string.IsNullOrEmpty(this.State))
                _errors.AppendLine("Estado inválido.");

            if (string.IsNullOrEmpty(this.City))
                _errors.AppendLine("Cidade inválida.");

            if (string.IsNullOrEmpty(this.Cep))
                _errors.AppendLine("CEP inválido.");

            if (string.IsNullOrEmpty(this.Street))
                _errors.AppendLine("Rua inválida.");

            if (string.IsNullOrEmpty(this.Number))
                _errors.AppendLine("Número inválido.");

            if (string.IsNullOrEmpty(this.Phone))
                _errors.AppendLine("Telefone inválido.");
        }

        public virtual void AddOwner(Player owner)
        {
            Owner = owner;
        }
    }
}
