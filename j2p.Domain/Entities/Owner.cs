using j2p.Domain.Entities.Base;
using j2p.Domain.Extensions;
using j2p.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace j2p.Domain.Entities
{
    public class Owner : User
    {
        protected Owner()
        {

        }

        public Owner(Name name, Email email, string password, string phone, string cpf, string cnpj)
        {
            Name = name;
            Email = email;
            Password = password;
            Password = Password.ConvertToMD5();
            Phone = phone;
            Cpf = cpf;
            Cnpj = cnpj;

            AddNotifications(name, email);
        }

        public string Cpf { get; protected set; }
        public string Cnpj { get; protected set; }
    }
}
