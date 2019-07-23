using System;

namespace j2p.Presentation.Api.ViewModels
{
    public class LocalViewModel
    {
        public Guid Id { get; set; }

        public string Country { get; set; }

        public string State { get; set; }

        public string City { get; set; }

        public string Cep { get; set; }

        public string Street { get; set; }

        public string Number { get; set; }

        public string Complement { get; set; }

        public string Phone { get; set; }

        public string Type { get; set; }

        public OwnerViewModel Owner { get; set; }
    }
}
