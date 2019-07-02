using j2p.Domain.Entities.Base;
using j2p.Domain.Extensions;

namespace j2p.Domain.Entities
{
    public class User : EntityBase
    {
        public string FirstName { get; protected set; }

        public string LastName { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public string Phone { get; protected set; }

        protected User()
        {

        }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
            Password = Password.ConvertToMD5();
        }

        public User(string firstName, string lastName, string email, string password, string phone)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            Password = Password.ConvertToMD5();
            Phone = phone;
        }
    }
}
