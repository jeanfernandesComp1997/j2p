using j2p.Domain.ValueObjects;

namespace j2p.Domain.Entities
{
    public class Player : User
    {
        public string Picture { get; protected set; }

        protected Player()
        {

        }

        public Player(Name name, Email email, string password, string phone, string picture) : base(name, email, password, phone)
        {
            Picture = picture;
        }
    }
}
