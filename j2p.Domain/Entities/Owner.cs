using j2p.Domain.ValueObjects;

namespace j2p.Domain.Entities
{
    public class Owner : User
    {
        public string Cpf { get; protected set; }
        public string Cnpj { get; protected set; }

        protected Owner()
        {

        }

        public Owner(Name name, Email email, string password, string phone, string cpf, string cnpj) : base(name, email, password, phone)
        {
            Cpf = cpf;
            Cnpj = cnpj;

            AddNotifications(name, email);
        }
    }
}
