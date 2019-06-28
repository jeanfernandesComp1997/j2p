using prmToolkit.NotificationPattern;

namespace j2p.Domain.ValueObjects
{
    public class Name : Notifiable
    {
        public string FirstName { get; private set; }

        public string LastName { get; private set; }

        protected Name()
        {

        }

        public Name(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;

            new AddNotifications<Name>(this)
                .IfNullOrInvalidLength(x => x.FirstName, 1, 50, "O primeiro nome deve conter de 1 a 50 caracteres.").IfNullOrInvalidLength(x => x.LastName, 1, 50, "O segundo nome deve conter entre 3 a 50 caractres.");
        }
    }
}
