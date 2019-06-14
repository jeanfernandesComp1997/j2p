using j2p.Domain.Entities.Base;
using j2p.Domain.Extensions;
using j2p.Domain.ValueObjects;

namespace j2p.Domain.Entities
{
    public class User : EntityBase
    {
        public Name Name { get; protected set; }

        public Email Email { get; protected set; }

        public string Password { get; protected set; }

        public string Phone { get; protected set; }

        protected User()
        {

        }

        public User(Email email, string password)
        {
            Email = email;
            Password = password;
            Password = Password.ConvertToMD5();

            AddNotifications(email);
        }

        public User(Name name, Email email, string password, string phone)
        {
            Name = name;
            Email = email;
            Password = password;
            Password = Password.ConvertToMD5();
            Phone = phone;
        }
    }
}
