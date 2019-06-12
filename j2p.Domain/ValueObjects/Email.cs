using prmToolkit.NotificationPattern;

namespace j2p.Domain.ValueObjects
{
    public class Email : Notifiable
    {
        protected Email()
        {

        }

        public Email(string adress)
        {
            Adress = adress;

            new AddNotifications<Email>(this)
                .IfNotEmail(x => x.Adress, "Endereço de email inválido.");
        }

        public string Adress { get; private set; }
    }
}
