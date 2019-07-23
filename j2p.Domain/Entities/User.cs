using j2p.Domain.Entities.Base;
using j2p.Domain.Extensions;

namespace j2p.Domain.Entities
{
    public class User : EntityBase
    {
        public virtual string FirstName { get; protected set; }

        public virtual string LastName { get; protected set; }

        public virtual string Email { get; protected set; }

        public virtual string Password { get; protected set; }

        public virtual string Phone { get; protected set; }

        public User()
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

        public override void Validate()
        {
            if (string.IsNullOrEmpty(this.FirstName))
                _errors.AppendLine("Primeiro nome inválido.");

            if (string.IsNullOrEmpty(this.LastName))
                _errors.AppendLine("Segundo nome inválido.");

            if (string.IsNullOrEmpty(this.Email) || !this.Email.ValidateEmail())
                _errors.AppendLine("Email inválido.");

            if (string.IsNullOrEmpty(this.Password))
                _errors.AppendLine("Senha inválida.");

            if (string.IsNullOrEmpty(this.Phone))
                _errors.AppendLine("Telefone inválido.");
        }
    }
}
