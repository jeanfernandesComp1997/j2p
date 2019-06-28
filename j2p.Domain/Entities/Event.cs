using j2p.Domain.Entities.Base;
using prmToolkit.NotificationPattern;
using System;
using System.Collections.Generic;

namespace j2p.Domain.Entities
{
    public class Event : EntityBase
    {
        public string Title { get; protected set; }
        public DateTime Date { get; protected set; }
        public double Value { get; protected set; }
        public int Limit { get; protected set; }
        public string Status { get; protected set; }
        public User Organizer { get; protected set; }
        public List<User> Players { get; protected set; }
        public Local Local { get; protected set; }

        protected Event()
        {

        }

        public Event(string title, DateTime date, double value, int limit, string status, User organizer, List<User> players, Local local)
        {
            Title = title;
            Date = date;
            Value = value;
            Limit = limit;
            Status = status;
            Organizer = organizer;
            Players = players;
            Local = local;

            new AddNotifications<Event>(this)
                .IfNullOrInvalidLength(x => x.Title, 2, 50, "O Título é obrigatório e deve conter entre 2 e 50 caracteres.")
                .IfNotDate(x => x.Date.ToString(), "Data inválida.")
                .IfNotNull(x => x.Value, "O campo Valor não pode ser vazio.")
                .IfNotNull(x => x.Limit, "O campo Limite não pode ser vazio.");

            AddNotifications(organizer);
            AddNotifications(local);
        }
    }
}
