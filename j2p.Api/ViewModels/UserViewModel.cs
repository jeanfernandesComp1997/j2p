using System;

namespace j2p.Presentation.Api.ViewModels.AddViewModel
{
    public abstract class UserViewModel
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Phone { get; set; }
    }
}
