
namespace j2p.Domain.Entities
{
    public class Owner : User
    {
        public string Cpf { get; protected set; }
        public string Cnpj { get; protected set; }

        protected Owner()
        {

        }

        public Owner(string firstName, string lastName, string email, string password, string phone, string cpf, string cnpj) : base(firstName, lastName, email, password, phone)
        {
            Cpf = cpf;
            Cnpj = cnpj;
        }
    }
}
