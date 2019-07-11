using System;
using System.Collections.Generic;

namespace j2p.Domain.Entities
{
    public class Player : User
    {
        public virtual string Picture { get; protected set; }

        public virtual List<Event> Events { get; protected set; }

        public Player()
        {

        }

        public Player(string firstName, string lastName, string email, string password, string phone, string picture) : base(firstName, lastName, email, password, phone)
        {
            Picture = picture;
        }

        public override void Validate()
        {
            base.Validate();

            if (_errors.Length > 0)
                throw new Exception(_errors.ToString());
        }
    }
}
