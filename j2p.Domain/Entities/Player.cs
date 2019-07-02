namespace j2p.Domain.Entities
{
    public class Player : User
    {
        public string Picture { get; protected set; }

        protected Player()
        {

        }

        public Player(string firstName, string lastName, string email, string password, string phone, string picture) : base(firstName, lastName, email, password, phone)
        {
            Picture = picture;
        }
    }
}
