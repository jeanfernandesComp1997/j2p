using System;

namespace j2p.Domain.Entities
{
    public class Owner : User
    {
        public virtual string Cpf { get; protected set; }
        public virtual string Cnpj { get; protected set; }

        protected Owner()
        {

        }

        public Owner(string firstName, string lastName, string email, string password, string phone, string cpf, string cnpj) : base(firstName, lastName, email, password, phone)
        {
            Cpf = cpf;
            Cnpj = cnpj;
        }

        public override void Validate()
        {
            base.Validate();

            if (_errors.Length > 0)
                throw new Exception(_errors.ToString());
        }
    }
}
